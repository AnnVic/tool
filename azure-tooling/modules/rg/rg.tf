variable "env" {
  type = map
}
resource "azurerm_resource_group" "rg" {
  location = var.env.location
  name     = var.env.rg_name

  tags = {
    Description = "Internship"
    Owner = "icaraman"
  }
}