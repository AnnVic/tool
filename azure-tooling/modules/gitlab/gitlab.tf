variable "gitlab" {
  type = map
}
resource "helm_release" "gitlab" {
  name       = "gitlab"
  repository = "https://charts.gitlab.io/"
  chart      = "gitlab"
  version    = var.gitlab.chart_version
  namespace  = "gitlab"
  create_namespace = true
  wait = true
  timeout = 600
  
########### GLOBAL CONFIGS ###########
  set {
    name = "global.ingress.class"
    value = "external-nginx"
  }

  set {
    name  = "global.hosts.domain"
    value = var.gitlab.domain_name
  }

  set {
    name  = "gitlabUrl"
    value = var.gitlab.gitlab_domain_name
  }
  
  set {
    name  = "global.hosts.externalIP"
    value = var.gitlab.fqdn
  }

  set {
    name  = "global.edition"
    value = "ce"
  }

  set {
    name  = "nginx-ingress.enabled"
    value = false
 }
 
  set {
    name  = "gitlab-shell.enabled"
    value = true
 }
############### POSTGRESQL ################

  set {
    name  = "postgresql.install"
    value = true
  }

########### PROMETHEUS & GRAFANA ############

set {
  name  = "grafana.install"
  value = false
}

set {
  name  = "grafana.enable"
  value = false
}

set {
  name  = "prometheus.install"
  value = false
}

set {
  name  = "prometheus_monitoring.enable"
  value = false
}

# set {
#     name  = "gitlab.webservice.monitoring.ipWhitelist"
#     value = "[\"10.0.97.67\"]"
#   }
########### RESOURCE OPTIMIZATION ###########
## MIN 2vCPU 6.25Gi RAM | MAX 3.5vCPU 12.5Gi RAM #

  set {
    name  = "global.appConfig.resources.requests.cpu"
    value = "500m"
  }

  set {
    name  = "global.appConfig.resources.requests.memory"
    value = "2Gi"
  }

  set {
    name  = "global.appConfig.resources.limits.cpu"
    value = "1"
  }

  set {
    name  = "global.appConfig.resources.limits.memory"
    value = "4Gi"
  }

  set {
    name  = "sidekiq.resources.requests.cpu"
    value = "500m"
  }

  set {
    name  = "sidekiq.resources.requests.memory"
    value = "2Gi"
  }

  set {
    name  = "sidekiq.resources.limits.cpu"
    value = "2"
  }

  set {
    name  = "sidekiq.resources.limits.memory"
    value = "4Gi"
  }

  set {
    name  = "gitaly.resources.requests.cpu"
    value = "500m"
  }

  set {
    name  = "gitaly.resources.requests.memory"
    value = "2Gi"
  }

  set {
    name  = "gitaly.resources.limits.cpu"
    value = "1"
  }

  set {
    name  = "gitaly.resources.limits.memory"
    value = "4Gi"
  }

########### TLS CONFIG ###########
   set {
    name  = "global.ingress.annotations.cert-manager\\.io/cluster-issuer"
    value = "cert-manager-global"
  }
 
  set {
    name  = "global.ingress.annotations.appgw\\.ingress\\.kubernetes\\.io/health-probe-status-codes"
    value = "200-499"
  }

  set {
    name  = "global.ingress.annotations.appgw\\.ingress\\.kubernetes\\.io/ssl-redirect"
    value = "true"
  }

  set {
    name  = "global.ingress.annotations.cert-manager\\.io/acme-challenge-type"
    value = "http01"
  }
  
  set {
    name  = "global.ingress.configureCertmanager"
    value = false
  }

  set {
    name  = "global.ingress.tls.enabled"
    value = true
  }

  set {
    name  = "certmanager.install"
    value = false
  }

  set {
    name  = "certmanager-issuer.email"
    value = "daniel.moscalu@endava.com"
  }

  set {
    name  = "global.ingress.tls.secretName"
    value = "gitlab-tls-secret"
  }

}
