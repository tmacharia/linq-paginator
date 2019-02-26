# Linq Paginator

[![Build Status](https://travis-ci.org/devTimmy/linq-paginator.svg?branch=master)](https://travis-ci.org/devTimmy/linq-paginator)
[![Nuget](https://img.shields.io/nuget/v/LinqPaginator.svg?style=popout)](https://www.nuget.org/packages/LinqPaginator/)
[![Nuget](https://img.shields.io/nuget/dt/LinqPaginator.svg)](https://www.nuget.org/packages/LinqPaginator/)


Retrieve collection results from `IQueryable` or `IEnumerable` packaged into pages for easy fetching to enable lazy loading data on UI components in a fast way when pulling large sets of data.

### Usage

Install package from Nuget by running the following command in Package Manager Console.

```bash
Install-Package LinqPaginator -Version 1.0.5
```

Then go ahead add a using statement to reference the already downloaded package.

```c#
using LinqPaginator;
```

This library works with almost all arrays that inherit from `ICollection<T>` and it provides an extension method to paginate your collection as shown below passing a page number and the number of items to return per page.

#### Example:

```c#
IEnumerable<string> _names = new List<string>()
{
    "Test-001","Test-002","Test-003","Test-004","Test-005"
};

PagedResult<string> paged = _names.Paged(1,2);

```
