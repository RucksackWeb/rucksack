# ![rucksack](./EcommerceStore/wwwroot/images/rucksack_logo.PNG)
- This is a 3 week 2-person team project building an entire ecommerce web application using ASP.NET.

## About our ECommerce Store

### Our Products
- We sell high quality products that are divided into three different categories:
    1. Sound systems
    2. Gadgets
    3. Bags

### Claims
- We used claims to save user's fullname, email, role, and subscription status. 
Fullname is utilized to display users name on anywhere on the website to provide welcoming feeling in 
their experience. 
Role claim is used to identify their access status allowing the access on certain pages for security reasons.
Lastly, we created subscription claim. Which it displays with special deals only for those of ones who are 
signed-up for the subscription list.

### Policies
- Currently we have two policies that are being enforced in our application:
    1. AdminOnly
        - Admin Only policy only allow access for users with admin status to enter certain parts of our application for security reasons.
    2. Subscriber
        - Subscriber policy only allow Subscribers to see sepcial deals we will be holding in the future.
        - Currently, this policy has not been yet implemented yet, but it will be in short future.

### OAuth
- We implemented connecting with Microsoft and Google OAuth. Which allows any Google or Microsoft account
holders will be able to signin through those accounts and still enjoy the experience with our application.

### Database Schema
- Order
    - Order object is created when user is ready for payment of a basket.
    - Order object holds a basket ID and User ID, which is connected to a specific basket object of a user.
    - Also holds non-personal user information such as shipping address, datetime of payment, and subtotal of order. 

- Basket
    - Basket acts as a middle data that connects user table, order table, and basket item table.
    - Order and basket item holds basket ID. Each order and list of basket items are created per each basket object.
    - Basket holds list of basket items. Which represents the different products and its quantity.

- Basket item
    - Basket items hold a single product with property of quantity.
    - It holds a single product item, but as many quantity as possible in a basket.
    - Each basket items are connected to a single basket object.



## Getting Started

### Prerequisites

To run this application, following software is required:
1. Visual Studio 2017, [Down load VS2017](https://visualstudio.microsoft.com/downloads/).
2. Bash (Optional), [Down load Bash](https://git-scm.com/downloads).

### To Open our application
Follow these steps to run this application on your local mahine
1. In this VSTS, click 'Code' from the left menu bar.
2. On the top-right corner of your screen, click 'Clone'.
3. Either on your terminal, bash, or Visual Studio 2017, clone the url.
4. Once this repository had been cloned to your local machine, open the repository using your .NET or C# capable software.
5. Run the program.

Follow this step to run this application from Azure.
1. Click this link to open the application. http://lotofstuffcommerce.azurewebsites.net/


## Deployment

Current Application is deployed with Microsoft Azure application service. To open this application
with Azure [Click here](http://lotofstuffcommerce.azurewebsites.net/).


## Contributing


## Acknowledgments

* We utilized product images and information from [Uncrate.com](https://uncrate.com/).

