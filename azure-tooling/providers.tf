terraform {
  backend "azurerm" {
    resource_group_name   = "mddinternship-project-resources"
    storage_account_name  = "mddinternshipsa"
    container_name        = "tfstate"
    key                   = "terraform.tfstate"
  }
  required_providers {
    azapi = {
      source  = "azure/azapi"
      version = "~>1.5"
    }
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~>3.0"
    }
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = "~> 2.4"
    }
    helm = {
      source = "hashicorp/helm"
      version = ">=2.1.0"
    }
  }
}

provider "azurerm" {
  features {}
}

provider "helm" {
  kubernetes {
    host = local.data_config.0.host
    client_key = base64decode(local.data_config.0.client_key)
    client_certificate = base64decode(local.data_config.0.client_certificate)
    cluster_ca_certificate = base64decode(local.data_config.0.cluster_ca_certificate)
  }
}
provider "kubernetes" {
    host = local.data_config.0.host
    client_key = base64decode(local.data_config.0.client_key)
    client_certificate = base64decode(local.data_config.0.client_certificate)
    cluster_ca_certificate = base64decode(local.data_config.0.cluster_ca_certificate)
    
}
