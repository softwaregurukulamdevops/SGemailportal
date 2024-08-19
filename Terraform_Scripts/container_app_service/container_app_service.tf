provider "azurerm" {
  features {}
}

# Define the Resource Group
resource "azurerm_resource_group" "example" {
  name     = "rg-emailportal-container-rg"
  location = "eastus"
}

# Define the Linux App Service Plan for Containers
resource "azurerm_service_plan" "linux_plan" {
  name                = "rg-emailportal-linux-app-svc-plan"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  os_type             = "Linux"
  sku_name            = "B1"
}

# Define the Container-based App Service
resource "azurerm_app_service" "container_service" {
  name                = "rg-emailportal-container-app"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  app_service_plan_id = azurerm_service_plan.linux_plan.id

  
  site_config {
 
  }
}

# Output the URL
output "container_app_service_default_hostname" {
  value = azurerm_app_service.container_service.default_site_hostname
}