gocoin.NET
==========

A .NET client library for GoCoin payment gateway.

## Usage

```csharp
    var client = new Client
        {
            client_id       = "*****",
            client_secret   = "*****",
            scope           = "user_read user_read_write ...",
            redirect_uri    = "*****"
        };
    // if need to get access_token
    client.initToken();
    var bAuth = client.authorize_api();

    var user = client.api.user;
    var userInfo = user.self();
 ...
```

## Methods

### Users

##### user.self()
##### user.get(id)
##### user.update(user)
##### user.update_password(user)


### Merchants

##### merchant.get(id)
##### merchant.update(merchant)


### Accounts

##### accounts.alist(id)


### Invoices

##### invoices.create(merchantId, invoice)
##### invoices.get(id)
##### invoices.search(invoiceParams)


### License

Copyright 2014 GoCoin Pte. Ltd.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
