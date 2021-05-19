# The Products Resource

## Paths

### /products

#### GET

Parameters: ??

Responses:

200 OK

```[javascript]
{
"data": [
    { "id": 1, "name": "Eggs", "price": 2.30},
    { "id": 2, "name": "Bread", "price": 2.25}
    ],
"summary: {
    "mostExpensiveProduct": "Shampoo",
    "averagePrice": 12.99
}
}
```