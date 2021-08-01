//Instructions : 
1. After Getting the code , Please Clean and Build the code to generate the bin Folder.
2. Also Create the table and SPs as it is in your database. SPs and Tables are present in Sql Scripts folder.
3. Change the ConnectionString as per your ServerName/DatabaseName/UID/Password.
4. As this is web API only , I have used PostMan to send requests to the API.

//About the Project :
1. I have categoried the application at 3 different level.
	A. ProductType (For Example : Electonic/Clothings/Fitness)
	B. SubProductType (For Example : Mobiles/Sports wears/Gym accessories)
	C. ProductDetails (For example : Redmi Note 10 /Samsum Galaxy 11)
2. Example of the Product Tree in format ProductType->SubProductType->ProductDetails:
	Electronic->Mobiles->Samsung Galaxy 11
3. Server Side Pagination is done only for ProductDetails.

I Have added Postman screenshots of requests and responses as well as database entry for all the Three Types.
Those Screenshots are present in Output folder.