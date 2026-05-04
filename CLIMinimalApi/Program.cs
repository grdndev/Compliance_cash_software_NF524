using CLICore.Data;
using CLICore.Dtos;
using CLICore.Services.Logger;
using CLIPrestashopConnector.Services.Push;
using CLIPrestashopConnector.Dtos;
using CLIPrestashopConnector.Models;
using CLIPrestashopConnector.Services;
using CLIPrestashopConnector.Services.Address;
using CLIPrestashopConnector.Services.CartRule;
using CLIPrestashopConnector.Services.Country;
using CLIPrestashopConnector.Services.Customer;
using CLIPrestashopConnector.Services.Order;
using CLIPrestashopConnector.Services.PrestashopErrorDecoder;
using CLIPrestashopConnector.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Reporting.NETCore;
using CLIMinimalApi.Reports;
using Microsoft.ReportingServices.Interfaces;
using CLIMinimalApi.Middleware;


var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("App"));
builder.Services.AddDbContext<CLIContext>(
        options => options.UseSqlServer("name=App:ConnectionStringCLI", o => o.UseCompatibilityLevel(100)));
builder.Services.AddTransient<ILogService, LogService>();
builder.Services.AddTransient<IPushService, PushService>();
builder.Services.AddTransient<IPrestashopErrorDecoderService, PrestashopErrorDecoderService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICartRuleService, CartRuleService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService,OrderService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CliWebApi", Version = "v1" });
    c.EnableAnnotations();
    
    c.AddSecurityDefinition("ApiKeyAuth",
    new OpenApiSecurityScheme
    {
        Description = "XApiKey Atuthorization",
        Name = "XApiKey", // Authorization
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKey"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKeyAuth"
            }
        },
        new List<string>()
    }
});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.EnvironmentName== "Local" || app.Environment.EnvironmentName== "Development" || app.Environment.EnvironmentName== "Staging" || app.Environment.EnvironmentName== "DevelopmentPrestashopLocal" || app.Environment.EnvironmentName == "DevelopmentPrestashopOnline")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ApiKeyMiddleware>();
app.UseHsts();
app.UseHttpsRedirection();

#region Test
app.MapGet("/", () =>
{
    return $"Current date and time is {DateTime.Now}";
}).WithTags("Default");

#endregion
#region Customer
//app.MapPost("/customer/ToCLI", (ICustomerService _customerService, ToCliDto toCliDto) =>
//{
//    return _customerService.UpdateCLIfromPSByIdAsync(toCliDto.Id);
//});

//app.MapPost("/customer/DeleleAllPS", (ICustomerService _customerService) =>
//{
//    return _customerService.DeleteAllCustomer();
//});

//app.MapPost("/customer/ImportPSfromCLI", (ICustomerService _customerService) =>
//{
//    return _customerService.ImportPSfromCLI();
//});

//app.MapPost("/customer/SyncFromCLI", (ICustomerService _customerService,[FromBody] long id) =>
//{
//    return _customerService.SyncFromCLI(id);
//});

//app.MapPost("/customer/FullSyncFromCLI", (ICustomerService _customerService, [FromBody] long id) =>
//{
//    return _customerService.FullSyncFromCLI(id);
//});

app.MapPost("/customer/DeleteCLIByIdAsync", async (ICustomerService _customerService, ToCliDto toCliDto) =>
{
    var retour = await _customerService.DeleteCLIByIdAsync(toCliDto.Id);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer un client dans CLI à partir de son Id", "Id du client dans CLI")).WithTags("Customer") ;

app.MapPost("/customer/DeletePSByIdAsync", async (ICustomerService _customerService, ToCliDto toCliDto) =>
{
    var retour = await _customerService.DeletePSByIdAsync(toCliDto.Id);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
   
}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer un client PS à partir de son Id", "Id du client dans PS")).WithTags("Customer");

app.MapPost("/customer/AddOrUpdateCLIfromPSByIdAsync",async (ICustomerService _customerService, ToCliDto toCliDto) =>
{
    var retour = await _customerService.AddOrUpdateCLIfromPSByIdAsync(toCliDto.Id, toCliDto.AssociatedAddress,toCliDto.AssociatedCartRule);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer un client CLI depuis PS", "Id du client dans PS")).WithTags("Customer");

app.MapPost("/customer/AddOrUpdatePSfromCLIByIdAsync", async (ICustomerService _customerService, ToCliDto toCliDto) =>
{
    var retour =  await _customerService.AddOrUpdatePSfromCLIByIdAsync(toCliDto.Id,toCliDto.AssociatedAddress, toCliDto.AssociatedCartRule);
    //retour.ResponseMessageLines.Where(e => e.Type == ResponseMessageType.Error).Count();
    
    return retour.ConstainsError?Results.BadRequest(retour):Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer un client PS depuis CLI", "Id du client dans CLI ")).WithTags("Customer");

app.MapPost("/customer/ImportFromCLIAsync", async (ICustomerService _customerService, ToCliDto toCliDto) =>
{
    var retour = await _customerService.ImportFromCLIAsync(toCliDto.AssociatedAddress, toCliDto.AssociatedCartRule,toCliDto.UpdatedDateFrom,toCliDto.OnlyErrors);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet d'importer les clients CLI dans PS","Adresses associées et Avoir associés")).WithTags("Customer");

app.MapPost("/customer/AddOrUpdateAvoirPSfromCLIByIdAsync", async (ICustomerService _customerService, ToCliDto toCliDto) =>
{
    var retour = await _customerService.AddOrUpdateAvoirPSfromCLIByIdAsync(toCliDto.Id);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer un avoir PS depuis CLI", "Id du client dans CLI ")).WithTags("Customer");

app.MapPost("/customer/EraseAllCustomersFromPSAsync", async (ICustomerService _customerService) =>
{
    var retour = await _customerService.EraseAllCustomersFromPSAsync();
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet des supprimer tous les clients (avant import de 0 par exemple", "")).WithTags("Customer");


#endregion

#region Address
//app.MapPost("/address/SyncFromCLI", (IAddressService _addressService, [FromBody] long id) =>
//{
//    return _addressService.SyncFromPSById(id);
//});

app.MapPost("/address/AddOrUpdateCLIfromPSByIdAsync", (IAddressService _addressService, ToCliDto toCliDto) =>
{
    return _addressService.AddOrUpdateCLIfromPSByIdAsync(toCliDto.Id);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer une adresse client CLI depuis PS","Id de l'adresse dans PS")).WithTags("Address");

app.MapPost("/address/AddOrUpdatePSfromCLIByIdAsync", async (IAddressService _addressService, ToCliDto toCliDto) =>
{
    var retour = await _addressService.AddOrUpdatePSfromCLIByIdAsync(toCliDto.Id);
    //retour.ResponseMessageLines.Where(e => e.Type == ResponseMessageType.Error).Count();

    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
  
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer une adresse client PS depuis CLI", "Id de l'adresse dans CLI")).WithTags("Address");

app.MapPost("/address/DeleteCLIByIdAsync", (IAddressService _addressService, ToCliDto toCliDto) =>
{
    return _addressService.DeleteCLIByIdAsync(toCliDto.Id);
}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer une adresse dans CLI à partir de son Id", "Id de l'adresse dans CLI")).WithTags("Address");

app.MapPost("/address/DeletePSByIdAsync", (IAddressService _addressService, ToCliDto toCliDto) =>
{
    return _addressService.DeletePSByIdAsync(toCliDto.Id);
}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer une adresse client PS à partir de son Id", "Id de l'adresse dans PS")).WithTags("Address");


#endregion

#region Country
app.MapPost("/country/PSGetCountryAsync", (ICountryService _countryService, [FromBody] string name) =>
{
    return _countryService.PSGetCountryAsync(name);
}).WithTags("Country");


#endregion

#region CartRule
app.MapPost("/cartrule/AddOrUpdatePSfromCLIByIdAsync", async (ICartRuleService _cartRuleService, ToCliDto toCliDto) =>
{
    var retour = await _cartRuleService.AddOrUpdatePSfromCLIByIdAsync(toCliDto.Id);
    //retour.ResponseMessageLines.Where(e => e.Type == ResponseMessageType.Error).Count();

    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer un avoir client PS depuis CLI", "Id de l'avoir dans CLI ")).WithTags("CartRule");

#endregion

#region Order
app.MapPost("/order/ImportFromPSByIdAsync", async (IOrderService _orderService, ToCliDto toCliDto) =>
{
    var retour = await _orderService.ImportFromPSByIdAsync(toCliDto.Id,toCliDto.Reference,toCliDto.Force);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet d'importer une commande PS dans CLI", "Id de la commande dans PS")).WithTags("Order");

app.MapPost("/order/UpdateOrderStatusFromCLIByIdAsync", async (IOrderService _orderService, ToCliDto toCliDto) =>
{
    var retour = await _orderService.UpdateOrderStatusFromCLIByIdAsync(toCliDto.Id);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour l'état d'une commande dans PS", "Id de la commande dans CLI")).WithTags("Order");


app.MapPost("/order/GetShippingCostAsync", async (IOrderService _orderService, ShippingCostDto shippingCostDto) =>
{
    var retour = await _orderService.GetShippingCostAsync(shippingCostDto);
    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de récupérer le coût de livraison d'une commande", "Id de la commande dans PS")).WithTags("Order");


app.MapPost("/order/GetInvoiceByOrderIdAsync",  async (IOrderService _orderService, ToCliDto toCliDto) =>
{
    var retour = await _orderService.GetOrderInvoiceFromCLIByIdAsync(toCliDto.Id);
   
    //Récupérer le contenu du fichier PDF si Objects contient un byte[] sinon renvoyer un fichier PDF vide
    if (retour.Objects.Count == 0 || !(retour.Objects.First() is byte[]))
    {
        return new FileContentResult(new byte[0], "application/pdf")
        {
            FileDownloadName = "error.pdf"
        };

    }
  
    byte[] reportContent = retour.Objects.First() as byte[];

    //Renvoyer le fichier PDF au client en utilisant un objet FileContentResult
    return new FileContentResult(reportContent, "application/pdf")
    {
        FileDownloadName = "facture.pdf"
    };

}).WithMetadata(new SwaggerOperationAttribute("Permet de récupérer le pdf de la facture d'une commande", "Id de la commande dans PS")).WithTags("Order");

app.MapPost("/order/SetInvoiceByOrderIdAsync",  async (IOrderService _orderService, ToCliDto toCliDto) =>
{
    var retour = await _orderService.SetOrderInvoiceFromCLIByIdAsync(toCliDto.Id,toCliDto.FactureData);
   
   return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de définir le pdf de la facture d'une commande", "Id de la commande dans CLI")).WithTags("Order");

#endregion
#region Product
app.MapPost("/product/AddOrUpdatePSfromCLIByIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.AddOrUpdatePSfromCLIByIdAsync(toCliDto.Id,toCliDto.AssociatedLegacyImages,importStock:toCliDto.ImportStock);

    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/AddOrUpdateMultiplePSfromCLIByIdsAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var responseMessages = await _productService.AddOrUpdateMultiplePSfromCLIByIdsAsync(toCliDto.Ids, toCliDto.AssociatedLegacyImages, toCliDto.ImportStock);
    return Results.Ok(responseMessages);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer plusieurs produits PS depuis CLI", "Ids des entetes de produits dans CLI")).WithTags("Product");

app.MapPost("/product/ImportFromLegacySubFamilyFromCLIByIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.ImportFromLegacySubFamilyFromCLIByIdAsync(toCliDto.Id,toCliDto.Id_T_Famille, toCliDto.AssociatedLegacyImages,toCliDto.OnlyErrors,toCliDto.OnlyNewSync,toCliDto.UpdatedDateFrom,toCliDto.ImportStock,toCliDto.DeleteBeforeImport);

    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour ou d'inserer des produits PS depuis CLI pour importation en fonction de la sous famille", "Id de la famille dans CLI ")).WithTags("Product");


app.MapPost("/product/DeletePSCombinaisonfromCLIByIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.DeletePSCombinaisonfromCLIByIdAsync(toCliDto.Id);

    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer une combinaison de produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");


app.MapPost("/product/UpdatePSStockfromCLIByIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.UpdatePSStockfromCLIByIdAsync(toCliDto.Id);

    return retour.ConstainsError ? Results.BadRequest(retour) : Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour le stock d'un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/GetImagePSfromCLIByIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.GetProductImage(toCliDto.Id,1);

    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet recuperer l'image d'un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/GetImagesPSfromCLIByIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.GetProductImages(toCliDto.Id);

    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet recuperer les images d'un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/GetProductDefaultImageIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.GetProductDefaultImageId(toCliDto.Id);

    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet recuperer l'image par défaut d'un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/SetProductDefaultImageIdAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.SetProductDefaultImage(toCliDto.Id,toCliDto.DefaultImageId);

    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour l'id de l'image par défaut d'un produit PS depuis CLI", "Id du produit dans CLI et DefaultImageId ")).WithTags("Product");



app.MapPost("/product/AddProductImagesAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
   
    var retour = await _productService.AddProductImages(toCliDto.Id,toCliDto.ToAddImages);

    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet d'ajouter une image à un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/DeleteProductImagesAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.DeleteProductImages(toCliDto.Id, toCliDto.ToDeleteImages);
    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer des image d'un produit PS depuis CLI", "Id du produit dans CLI ")).WithTags("Product");

app.MapPost("/product/SortProductOptionValueAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.SortProductOptionValueAsync(toCliDto.Id);
    return Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de trier les valeurs d'une option d'un produit PS", "Id de l'option PS ")).WithTags("Product");

app.MapPost("/product/GetAllProductOptionAsync", async (IProductService _productService) =>
{
    var retour = await _productService.GetAllProductOptionAsync();
    return Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de recuperer toutes les options de produit PS", "")).WithTags("Product");

app.MapPost("/product/DeleteProductFromPSWithNoMatchCLIAsync", async (IProductService _productService) =>
{
    var retour = await _productService.DeleteProductFromPSWithNoMatchCLIAsync();
    return Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de supprimer les produits PS qui n'ont pas de correspondance CLI", "")).WithTags("Product");

app.MapPost("/product/GetProductUrlFromPSAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.GetProductUrlFromPSAsync(toCliDto.Id);
    return Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de récupérer l'url d'un produit PS", "Id de l'entete de produit dans CLI")).WithTags("Product");
app.MapPost("/product/CleanPSFromCLIAsync", async (IProductService _productService) =>
{
    var retour = await _productService.CleanPSFromCLIAsync();
    return Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet de nettoyer les combinaisons ou produits activés à tord", "")).WithTags("Product");

app.MapPost("/product/EraseAllProductsFromPSAsync", async (IProductService _productService) =>
{
    var retour = await _productService.EraseAllProductsFromPSAsync();
    return Results.Ok(retour);

}).WithMetadata(new SwaggerOperationAttribute("Permet des supprimer tous les produit (avant import de 0 par exemple)", "")).WithTags("Product");

app.MapPost("/product/GetUniqueAvailableNowMessagesFromPSAsync", async (IProductService _productService) =>
{
    var retour = await _productService.GetUniqueAvailableNowMessagesFromPSAsync();
    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de récupérer les messages de disponibilité en stock uniques des produits PS", "")).WithTags("Product");

app.MapPost("/product/GetUniqueAvailableLaterMessagesFromPSAsync", async (IProductService _productService) =>
{
    var retour = await _productService.GetUniqueAvailableLaterMessagesFromPSAsync();
    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de récupérer les messages de disponibilité ultérieure uniques des produits PS", "")).WithTags("Product");

app.MapPost("/product/UpdateAvailableNowMessageAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.UpdateAvailableNowMessageAsync(toCliDto.CurrentMessage, toCliDto.NewMessage);
    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour le message disponible maintenant pour tous les produits correspondant au message actuel", "Message actuel et nouveau message")).WithTags("Product");

app.MapPost("/product/UpdateAvailableLaterMessageAsync", async (IProductService _productService, ToCliDto toCliDto) =>
{
    var retour = await _productService.UpdateAvailableLaterMessageAsync(toCliDto.CurrentMessage, toCliDto.NewMessage);
    return Results.Ok(retour);
}).WithMetadata(new SwaggerOperationAttribute("Permet de mettre à jour le message disponible ultérieurement pour tous les produits correspondant au message actuel", "Message actuel et nouveau message")).WithTags("Product");

#endregion
#region Log

// NF525 — endpoints d'effacement (/log/EraseAll, /log/EraseExceptLast,
// /log/EraseFrom, /log/EraseFromTo) supprimés définitivement.
// Conformité NF525 / Phase 1 du devis : interdiction de purge des logs,
// même par un administrateur. Les logs sont archivés (cf. ExporterArchiveFiscale).

// ✅ Lecture seule autorisée
app.MapPost("/log/GetAll", async (ILogService _logService) =>
{
    return Results.Ok(await _logService.GetAll());
}).WithTags("Log");
#endregion

#region CLI
// Identification employé



#endregion
app.Run();

