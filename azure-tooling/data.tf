data "azurerm_dns_zone" "example" {
  name                = "tool.mddinternship.com"
  resource_group_name = "mddinternship-project-resources"  
}
