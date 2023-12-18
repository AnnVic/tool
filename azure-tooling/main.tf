module "RG" {
    source = "./modules/rg"
    env = local.var
}
module "AKS" {
    source = "./modules/aks"
    depends_on = [ module.RG ]
    env = local.var
}
module "ARGOCD" {
    source = "./modules/argocd"
    depends_on = [ module.AKS ]   
}
module "INGRESS" {
    source = "./modules/ingress"
    depends_on = [ module.AKS ]
}

module "cert_manager" {
  source        = "terraform-iaac/cert-manager/kubernetes"

  cluster_issuer_email                   = "daniel.moscalu@endava.com"
  cluster_issuer_name                    = "cert-manager-global"
  cluster_issuer_private_key_secret_name = "cert-manager-private-key"
  depends_on = [ module.AKS ]

  solvers = [
    {
    http01 = {
      ingress = {
        class = "external-nginx"
      }
    }
  }
 ]
  certificates = {
    "wildcard-tls-secret" = {
      dns_names = ["*.tool.mddinternship.com"]
    }
  }
}
module "GITLAB" {
  source ="./modules/gitlab"
  depends_on = [ module.AKS ]
  gitlab = local.gitlab
}