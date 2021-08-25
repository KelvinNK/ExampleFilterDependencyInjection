# How to perform dependency injection on filters [.net core 3.1]

### In this example we'll implement the interface IAuthorizationFilter to perform the authorization of our controller.

1. Create the class that will be your filter.

![image](https://user-images.githubusercontent.com/31309938/111232514-fe854680-85c9-11eb-9919-e5484f90fe81.png)

2. Use the class "Atribbute" as base for your "CustomFilter".

![image](https://user-images.githubusercontent.com/31309938/111233072-114c4b00-85cb-11eb-9715-780b5f09f6a7.png)

3. Add "AtributeUsage" with AttributeTargets Class and Method, that way the filter can be used in the whole class or just in the method you want.

![image](https://user-images.githubusercontent.com/31309938/111233565-01813680-85cc-11eb-8d7a-dd3d50b7389f.png)

4. Add "using Microsoft.AspNetCore.Mvc.Filters" in your "Customfilter", then add the interface IAuthorizationFilter.

![image](https://user-images.githubusercontent.com/31309938/111234583-9c2e4500-85cd-11eb-9f82-b71c5ad403d9.png)

5. Implement the interface you just added.

![image](https://user-images.githubusercontent.com/31309938/111234725-f5967400-85cd-11eb-88fa-0aebc29f6e61.png)

In this method you can perform any logic you want to carry out the authorization.

6. For didactic reasons we'll define a key in appSettings.json must be passed at the Header of the request to be authorized.

![image](https://user-images.githubusercontent.com/31309938/111237169-49578c00-85d3-11eb-9133-a6bb0548bb2b.png)

To get that key from appSettings.json in our filter we'll need IConfiguration, this is where we need the dependency injection.

7. Add the interface "IFilterFactory" to the class "CustomFilter"

![image](https://user-images.githubusercontent.com/31309938/111238100-24641880-85d5-11eb-8b37-f1e0b9fff20c.png)

8. Implement IFilterFactory

![image](https://user-images.githubusercontent.com/31309938/111238271-84f35580-85d5-11eb-94fb-fdda41a0b283.png)

9. Add "using Microsoft.Extensions.Configuration", create a attribute type "IConfiguration" and a constructor that receives a param type "IConfiguration".

![image](https://user-images.githubusercontent.com/31309938/111238629-31cdd280-85d6-11eb-94e5-5bd551ae8eac.png)

10. In the method "CreateInstance" add:

![image](https://user-images.githubusercontent.com/31309938/111238738-722d5080-85d6-11eb-82ae-edb8a13aff54.png)

11. In the constructor add:

![image](https://user-images.githubusercontent.com/31309938/111238807-a0ab2b80-85d6-11eb-8027-a9c459fa0db6.png)

12. Now use the "\_configuration" to get the key and make your logic on the "OnAuthorization" method.

![image](https://user-images.githubusercontent.com/31309938/111239055-229b5480-85d7-11eb-8857-774aef4e6360.png)

13. Just add the filter to your controller like this and voila :)

![image](https://user-images.githubusercontent.com/31309938/111239498-11067c80-85d8-11eb-94ad-82e70c4ce619.png)

