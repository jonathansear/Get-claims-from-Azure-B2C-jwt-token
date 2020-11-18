# Convert the ClaimsPrincipal object returned by Azure B2C into this adapter to read the user claims

## Introduction  

<p>For applications leveraging Azure B2C which want a clean way to read the claims you have passed in your workflow back to the application. </p>
<p>This small lightweight library unpicks all the claims in the <b>ClaimsPrincipal</b>.</p>

## Usage   

```C#
ClaimProperties UserClaims = _tokenManager.ConvertClaims(User.Identities.FirstOrDefault().Claims);

string name = UserClaims.name;

string jobTitle = UserClaims.jobTitle;
```

## Setup   

1. Your application must already be using Azure B2C. You should see something similar <b>startup.cs</b>.
   ```C#
    services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
                .AddAzureADB2C(options => Configuration.Bind(CurrentEnvironment.IsDevelopment() ? "AzureAdB2CDev" : "AzureAdB2C", options));
    ```
    
2. Add a project reference to the <b>Managers</b> class libary from within this repo.  
3. Register the dependency in your <b>startup.cs</b>. 
  ```C#
public void ConfigureServices(IServiceCollection services)
        {
            //Add Token Manager to dependency injection 
            services.Add(new ServiceDescriptor(typeof(ITokenManager), new TokenManager()));
        }
  ```
    
4. Finally Inject it into your controller 
```C#
        ITokenManager _tokenManager;

        public HomeController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public IActionResult Index()
        {
            ClaimProperties UserClaims = _tokenManager.ConvertClaims(User.Identities.FirstOrDefault().Claims);

            string name = UserClaims.name;

            string jobTitle = UserClaims.jobTitle;

            return View();
        }
   
