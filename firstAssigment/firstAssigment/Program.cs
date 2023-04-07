/*Requirement: Create an Asp.Net Core Web Application that receives HTTP GET request (from Postman). 
 It receives "firstNumber", "secondNumber" and "operation" as inputs as query as a part of the URL.



Parameters:

firstNumber: Any int value

secondNumber: Any int value

operation: "+", "-", "*", "/" or "%"

Finally, it should return the result of the specified operation performed on firstNumber and secondNumber



Example #1:

If you receive a HTTP GET request at path "/", if firstNumber, secondNumber and operator are submitted, it should perform the given operation and return HTTP 200 response.

Request Url: /?firstNumber=5&secondNumber=2&operation=add

Request Method: GET

Response Status Code: 200

Response Body (output): 7





Example #2:

If you receive a HTTP GET request at path "/", if firstNumber, secondNumber and operator are submitted, it should perform the given operation and return HTTP 200 response.

Request Url: /?firstNumber=5&secondNumber=2&operation=multiply

Request Method: GET

Response Status Code: 200

Response Body (output): 10





Example #3:

If you receive a HTTP GET request at path "/", if firstNumber, secondNumber and operator are submitted, if "operation" is incorrect, it should return HTTP 200 response.

Request Url: /?firstNumber=5&secondNumber=2&operation=something

Request Method: GET

Response Status Code: 400

Response Body (output): Invalid input for 'operation'





Example #4:

If you receive a HTTP GET request at path "/", if neither firstNumber, secondNumber and operator are submitted, return HTTP 400 response.

Request Url: /

Request Method: GET

Response Status Code: 400

Response Body (output):

Invalid input for 'firstNumber'

Invalid input for 'secondNumber'

Invalid input for 'operation'





Example #5:

If you receive a HTTP GET request at path "/", if any one of firstNumber, secondNumber and operator is not submitted, it should return HTTP 400 response.

Request Url: /?firstNumber=7

Request Method: GET

Response Status Code: 400

Response Body (output):

Invalid input for 'secondNumber'

Invalid input for 'operation'





Instructions:

Use app.Run() method to define code for calculation of result based on given numbers and operation

The user can only supply two numbers as "firstNumber" and "secondNumber" parameters.

The "firstNumber", "secondNumber" and "operation" values are mandatory

Return appropriate HTTP status codes based on above examples.

Do not create controllers or any other concept which is not yet covered, to avoid confusion.*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Terminating middleware
app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        int firstNumber = 0, secondNumber = 0;
        string? operation = null; // This means that string can receive a nullable value
        long? result = null;

        //read 'firstNumber' if submitted in the request body
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            string firstNumberString = context.Request.Query["firstNumber"][0];
            if (!string.IsNullOrEmpty(firstNumberString))
            {
                firstNumber = Convert.ToInt32(firstNumberString);
            }
            else
            {
                context.Response.StatusCode = 400; // used for responde only
                await context.Response.WriteAsync("Invalid input for 'firstNumber'\n"); // This will write once the operation is finished
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
        }

        //read 'secondNumber' if submitted in the request body
        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            string secondNumberString = context.Request.Query["secondNumber"][0];
            if (!string.IsNullOrEmpty(secondNumberString))
            {
                secondNumber = Convert.ToInt32(context.Request.Query["secondNumber"][0]);
            }
            else
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
        }

        //read 'operation' if submitted in the request body
        if (context.Request.Query.ContainsKey("operation"))
        {
            operation = Convert.ToString(context.Request.Query["operation"][0]);

            //perform the calculation based on the value of "operation"
            switch (operation)
            {
                case "add": result = firstNumber + secondNumber; break;
                case "subtract": result = firstNumber - secondNumber; break;
                case "multiply": result = firstNumber * secondNumber; break;
                case "divide": result = (secondNumber != 0) ? firstNumber / secondNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
                case "mod": result = (secondNumber != 0) ? firstNumber % secondNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
            }

            //If no case matched above, the "result" remains as 'null'
            if (result.HasValue)
            {
                await context.Response.WriteAsync(result.Value.ToString());
            }

            //if invalid value is submitted for "operation" parameter
            else
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
            }

        } //end of "of ContainsKey("operation")

        //if the "operation" parameter is submitted from the client
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'operation'\n");
        }
    }
});

app.Run();
