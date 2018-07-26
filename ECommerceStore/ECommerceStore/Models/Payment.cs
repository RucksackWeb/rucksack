using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ECommerceStore.Models.ViewModels;

namespace ECommerceStore.Models
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class Payment
    {
        private IConfiguration Configuration;

        public Payment(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public string RunPayment(CheckoutViewModel cvm)
        {
            // Set the environment that will be running
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define the merchant information (authentication / transaction id )
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication =
                new merchantAuthenticationType()
                {
                    name = Configuration["Auth.Net:ApiId"],
                    ItemElementName = ItemChoiceType.transactionKey,
                    Item = Configuration["Auth.Net:TransactionKey"],
                };

            customerAddressType billingAddress = GetAddress(cvm);

            var request = GetPaymentInfo(cvm);

            // instantiate the controller that will call the service
            var controller = new createTransactionController(request);
            controller.Execute();


            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.transactionResponse.messages != null)
                {
                    // passed
                    var r1 = response.transactionResponse.transId;
                    var r2 = response.transactionResponse.responseCode;
                    var r3 = response.transactionResponse.messages[0].code;
                    var r4 = response.transactionResponse.messages[0].description;
                    var r5 = response.transactionResponse.authCode;
                    return $"passed, {r4}";
                }
                else
                {
                    // failed
                    var r1 = response.transactionResponse.transId;
                    var r2 = response.transactionResponse.responseCode;
                    var r3 = response.transactionResponse.messages[0].code;
                    var r4 = response.transactionResponse.messages[0].description;
                    var r5 = response.transactionResponse.authCode;
                    return $"Payment failed, {r4}";
                }

            }
            else
            {
                // failed
                var r1 = response.transactionResponse.errors[0].errorCode;
                var r2 = response.transactionResponse.errors[0].errorText;
                return $"Paymed failed, {r2}";
            }
        }


        private static customerAddressType GetAddress(CheckoutViewModel cvm)
        {
            customerAddressType address = new customerAddressType()
            {
                firstName = cvm.User.FirstName,
                lastName = cvm.User.LastName,
                address = cvm.BillingStreet,
                city = cvm.BillingCity,
                state = cvm.BillingState,
                zip = cvm.BillingZipcode
            };

            return address;
        }


        private static createTransactionRequest GetPaymentInfo(CheckoutViewModel cvm)
        {
            long ccnumber = (long)cvm.CC;
            var creditcard = new creditCardType
            {
                cardNumber = ccnumber.ToString(),
                expirationDate = cvm.ExpireDate
            };

            var paymentType = new paymentType
            {
                Item = creditcard
            };

            //lineItemType[] lineItems = GetArrItem(cvm.Order.Items);

            transactionRequestType transactiontype =  new transactionRequestType
            {
                transactionType = transactionTypeEnum.authOnlyTransaction.ToString(),
                amount = cvm.Order.Subtotal,
                payment = paymentType,
                //lineItems = lineItems                 
            };

            return new createTransactionRequest
            {
                transactionRequest = transactiontype
            };
        }


        private static lineItemType[] GetArrItem(List<BasketItem> items)    
        {
            lineItemType[] lineItems = new lineItemType[items.Count];
            int counter = 0;
            foreach(BasketItem item in items)
            {
                lineItems[counter] = new lineItemType
                {
                    itemId = item.Product.ID.ToString(),
                    name = item.Product.Name,
                    description = item.Product.Description,
                    quantity = item.Quantity,
                    unitPrice = item.Product.Price

                };
                counter++;
            }
            return lineItems;
        }
    }

}
