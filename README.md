# .NET
.NET code samples for sending requests to Payscout Gateway API 


This plugin is released under the GPL license.

**If you have any questions or issues, feel free to contact our technical support: support@payscout.com. You can also contact our 24X7 phone support - Tel: 1.888.689.6088

The .NET framework is a programming infrastructure for building, deploying, and running applications and services that use .NET technologies.

From your ecommerce website or VB.NET, C# or managed C++ back-office system to our platform, our .NET SDK allows for quick and simple connectivity. Download our SDK, install it, and start testing immediately.

Please contact you Payscout Support Representative for assistance in matching you with the SDK that best fits your needs.
## Table of Contents

1. [Auth Example](#auth)
1. [Capture Example](#capture)
1. [Credit Example](#credit)
1. [Void Example](#void)
1. [Sale Example](#sale)
1. [Refund Example](#refund)
1. [Responses](#responses)


##Auth Example

##Capture Example

##Credit Example

##Void Example

##Sale Example

##Refund Example

##Responses

1. Success JSON response
{"status":"approved","gateway_mid":"A0***","transaction_id":"A*********Q","message":"Transaction approved","result_code":"000","extended_info":"<token></token>","cvv2_verification_code":"M","avs_code":"N"}

2. Error in authentication

{"status":"declined","message":"authentication-failed"}

3. Error in values sent for fields

{"status":"declined","message":"Bad request: Bad value for: 'account_number'"}

4. Error in mandatory fields

{"status":"declined","message":"Bad request: Missing properties: [account_number]"}

5. Denied transactions

{"status":"declined","gateway_mid":"A0***","transaction_id":"A*********F","message":"ERROR : Error ( Error ( Card expired ) while reading transaction details ) while trying to read the parameters for request 797774"}
