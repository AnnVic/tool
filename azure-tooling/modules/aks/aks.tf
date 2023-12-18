variable "env" {
  type = map
}
resource "azurerm_kubernetes_cluster" "example" {
  name                = var.env.name
  location            = var.env.location
  resource_group_name = var.env.rg_name
  dns_prefix          = var.env.dns_prefix
  default_node_pool {
    name       = "default"
    node_count = 2
    vm_size    = "Standard_B4ms"
  }
  identity {
    type = "SystemAssigned"
  }

  tags = {
    Description = "Internship"
    Owner = "icaraman"
  }
}

output "client_certificate" {
  value     = azurerm_kubernetes_cluster.example.kube_config.0.client_certificate
  sensitive = true
}

output "kube_config" {
  value = azurerm_kubernetes_cluster.example.kube_config
  sensitive = true
}
output "kubernetes_cluster_fqdn" {
  value = azurerm_kubernetes_cluster.example.fqdn
}
