### 1. [HttpPost("api/v1/vehicle{vehicleNumber}")]

## Body -
```json
   {
    "vehicleNumber": "DL2001",
    "date": "2024-01-13T10:30:00Z",
    "fuel": 20.0,
    "price": 2000.0,
    "driverName": "Salim",
    "fuelType": "Petrol"
    }
```
## Status Code - 201 

### 2. [HttpPut("api/v1/vehicle/{vehicleNumber}/correct")]

## Body -
```json
   {
        "id": "074a29fb-fd89-4f57-a3da-abfeaa7c7f05",
        "vehicleNumber": "DL2000",
        "date": "2024-01-13T10:30:00Z",
        "fuelAmount": 0,
        "price": 2000,
        "driverName": "Salim",
        "fuelType": "Diesel"
    }
```
##  Status Code - 200

### 3. [HttpDelete("api/v1/vehicle/{recordId}")]
##  Status Code - 200

### 4. [HttpGet("api/v1/vehicle/{vehicleNumber}/history")]

## Response -
```json
   [
    {
        "id": "074a29fb-fd89-4f57-a3da-abfeaa7c7f05",
        "vehicleNumber": "DL2000",
        "date": "2024-01-13T10:30:00Z",
        "fuelAmount": 0,
        "price": 2000,
        "driverName": "Salim",
        "fuelType": "Diesel"
    }
]
```
##  Status Code - 200

### 5. [HttpGet("api/v1/vehicle/all")]
## Response -
```json [
    {
        "id": "aef70ae4-d96d-4853-9b05-28de23390999",
        "vehicleNumber": "DL2001",
        "date": "2024-01-13T10:30:00Z",
        "fuelAmount": 0,
        "price": 2000,
        "driverName": "Salim",
        "fuelType": "Petrol"
    }
]
```
##  Status Code - 200



   
