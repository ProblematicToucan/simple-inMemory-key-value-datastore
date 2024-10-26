# Formulatrix Repo Library

## Overview

The **Formulatrix Repo** library provides a simple and effective way to register, retrieve, and manage data in various formats, including JSON and XML. This library is designed to help developers easily store and manage their data with type validation.

## Features

- Register data with a unique key.
- Retrieve data by key.
- Deregister (remove) data by key.
- Validate data formats (JSON and XML) upon registration.
- Prevent overwriting of existing keys unless explicitly handled.

## Installation

To use this library, include it in your C# project via NuGet or directly add the project reference.

```bash
dotnet add package Formulatrix.Repo
```

# Usage

## Initialization
You can initialize the Repo class as follows:

```cs
var repo = new Repo();
```

## Registering Data
To register data, use the Register method. The method requires a unique key, the data in string format, and an integer to indicate the data type (1 for JSON, 2 for XML).

```cs
repo.Register("key", jsonData, 1); // For JSON
repo.Register("key", xmlData, 2);  // For XML
```

## Retrieving Data
To retrieve data by its key, use the Retrieve method:
```cs
string data = repo.Retrieve("key");
```

## Deregistering Data
To remove data from the repository, use the Deregister method:
```cs
repo.Deregister("key");
```

## Validating Data
The library performs validation on data formats. Attempting to register invalid JSON or XML will throw an ArgumentException.
```cs
repo.Register("key", invalidJsonData, 1); // Throws exception if invalid JSON
repo.Register("key", invalidXmlData, 2);  // Throws exception if invalid XML
```

## Overwriting Data
If you attempt to register data with a key that already exists, the library will throw an ArgumentException unless the existing data is explicitly handled.
```cs
repo.Register("existingKey", jsonData, 1); // First registration
repo.Register("existingKey", xmlData, 2);   // Throws exception
```

# Unit Tests

The library comes with a suite of unit tests to verify its functionality. The tests cover:

Initialization of the Repo instance.
Successful registration and retrieval of data.
Deregistration of data.
Validation of correct data formats.
Error handling for duplicate keys.
Run the unit tests using the following command:
```cs
dotnet test
```

