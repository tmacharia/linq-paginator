# Linq Paginator

[![Build status](https://ci.appveyor.com/api/projects/status/fi3hf87pwmtdmsor?svg=true)](https://ci.appveyor.com/project/tmacharia/linq-paginator)
[![Nuget](https://img.shields.io/nuget/v/LinqPaginator.svg?style=popout)](https://www.nuget.org/packages/LinqPaginator/)
[![Nuget](https://img.shields.io/nuget/dt/LinqPaginator.svg)](https://www.nuget.org/packages/LinqPaginator/)


Retrieve collection results from `IQueryable<T>`, `IEnumerable<T>` or any array based data type that inherits `ICollection<T>` and packages the results into pages for easy fetching to enable lazy loading data on UI components in a fast way when pulling large sets of data.

### Install

Install package from Nuget by running the following command in Package Manager Console.

```bash
Install-Package LinqPaginator -Version 1.0.6
```

Then go ahead add a using statement to reference the already downloaded package.

```c#
using LinqPaginator;
```

This library works with almost all arrays that inherit from `ICollection<T>` and it provides an extension method to paginate your collection as shown below passing a page number and the number of items to return per page.

#### Sample Data:

```c#
IList<string> _names = new List<string>();
_names.Add("Test-01");
_names.Add("Test-02");
_names.Add("Test-03");
_names.Add("Test-04");
_names.Add("Test-05");
```
