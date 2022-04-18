Note:
This Project is crated in ASP .Net Core 5.0 by using the Clean Architecture Approach.
	1. The Domain Project is created for Defining the Entities for 
		a. Product
		b. Rating
		c. CartItem 

	2. The Appliation Project is created for Defining the Applicable Interfaces and Function Definition
		a. IProductService was generated to handling the product opration.
		b. ICartItemsService is created to Cart Operations
	
	3. The Infrastructure Project is created to Implement the Definations of 
		a. IProductService
		b. ICartItemsService
	
	4. The WebUI Project is the FrontEnd of the Application OrderCart
		Cart and products are handeled through Vue.js throug Web API
	
			
	
		
