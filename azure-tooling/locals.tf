locals {
    var = {
       name = "mddinternship-aks"
       location = "westeurope" 
       rg_name = "mddinternship-aks-rg"  
       dns_prefix = "internship"
    }
    data_config = module.AKS.kube_config
    gitlab = {
        fqdn = "internship-21vyvh3z.hcp.westeurope.azmk8s.io"
        gitlab_domain_name = "gitlab.tool.mddinternship.com"
        chart_version = "7.5.0"
        domain_name = "tool.mddinternship.com"
    }
    
}  