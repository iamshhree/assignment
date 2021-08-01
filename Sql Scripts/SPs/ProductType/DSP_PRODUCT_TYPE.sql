Use tempdb
GO

Create PROCEDURE DSP_PRODUCT_TYPE  
@ProductTypeID AS VARCHAR(50)=NULL  
AS   
BEGIN  
 BEGIN TRY  
 If @ProductTypeID is null  
  Select PRODUCTTYPEID  , PRODUCTTYPENAME from MST_PRODUCTTYPE   
 else  
  Select PRODUCTTYPEID  , PRODUCTTYPENAME from MST_PRODUCTTYPE where ProductTypeId = @ProductTypeID  
  
 END TRY  
 BEGIN CATCH  
  SELECT 0 as Product_Type_ID  , 'Error Occured' as Output  
 END CATCH  
END  
  