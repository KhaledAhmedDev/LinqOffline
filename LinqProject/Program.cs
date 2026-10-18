using LinqProject.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using static LinqProject.Models.Source;
namespace LinqProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 01
            #region var vs dynamic
            //var name = "Khaled";  //Compiler Detecets the type : string Compilation Time
            //name="Ahmed"; //Valid
            //name = 99; //Compilation error

            //Console.WriteLine(name.GetType()); //System.String

            //Console.WriteLine(name.Length);

            //var y = null; //Compilation error : Compiler cannot detect type of Y from Null

            //var y; // Compiler error : without intialization, the compiler cannot infer the type of y

            //var x = "Khaled";
            //x = null; ; //Valid : because string is a reference type and can be null



            // Key word : Dynamic
            //dynamic value;  // can be declared without initialization
            //value = 42;
            //Console.WriteLine(value.GetType());  //System.Int32

            //value = true;
            //Console.WriteLine(value.GetType());  //System.Boolean

            //value = new Customer() { CustomerName = "Ali" };
            //Console.WriteLine(value.GetType());

            //Console.WriteLine(value.CustomerName);

            //value = "Hamada";
            //Console.WriteLine(value.CustomerName); //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: ''



            #endregion

            #region Anonymous Types
            //var employee1 = new { Id = 1, Name = "Ahmed", Salary = 5000 };   // Anynmous  0`3 [Id:int -name:string -salary:int]
            //																 //Console.WriteLine(employee1);

            ////Console.WriteLine(employee1.GetType());  //<>f__AnonymousType0`3[System.Int32,System.String,System.Int32]

            //var employee2 = new { Id = 2, Name = "Khaled", Salary = 7000 };

            ////Console.WriteLine(employee2.GetType());  //<>f__AnonymousType0`3[System.Int32,System.String,System.Int32]
            ////Same Property Names and Types and order => Same Anynmous Type


            //var employee3 = new { id = 3, name = "Omar", salary = 3000 };
            ////Console.WriteLine(employee3.GetType());   // <>f__AnonymousType1`3[System.Int32,System.String,System.Int32]  Different Property Names => Different Anynmous Type


            //var employee4 = new { Id = 4, Salary = 10000, Name = "Ali" }; //<>f__AnonymousType2`3[System.Int32,System.Int32,System.String]
            //Console.WriteLine(employee4.GetType());  // Different Property Order => Different Anynmous Type


            //===================Equality===========================

            // Equals() => Comapare Object based on Data not address
            // == > Comapare Object based on Address not Data

            //var employee01Copy = new { Id = 1, Name = "Ahmed", Salary = 5000 };
            ////Console.WriteLine(employee01Copy.GetType());

            ////Console.WriteLine(employee1.Equals(employee01Copy)); // Same Values => True

            ////Console.WriteLine(employee1==employee01Copy); // Not same reference => False


            ////===================Immutabilty=========================

            //// All properties of an anonymous type are read-only (immutable) and cannot be changed after initialization.

            ////employee1.Name = "Ali"; // Compilation Error : Cannot modify the value of an anonymous type property


            //// To change Value: or to make new objects with same values of another Object but i need to change one property

            ////1 Projection Intializzers

            //var employee5 = new { employee1.Id, employee1.Name, Salary = 6000 };

            ////Console.WriteLine(employee5);

            ////Console.WriteLine(employee1.GetType()==employee5.GetType());


            //// 2 With Expression [C#10]

            //var employee6 = employee1 with { Salary = 10000 };

            ////Console.WriteLine(employee6);

            ////Console.WriteLine(employee6.GetType()==employee1.GetType());

            ////Console.WriteLine(employee1);


            #endregion

            #region Query Syntax vs Method Syntax [Fluent Syntax]

            //List<Student> students = new List<Student>
            //{
            //	new Student(){Name="Sara",Grade=90,Major="CS"},
            //	new Student(){Name="Ali",Grade=85,Major="Math"},
            //	new Student(){Name="Omar",Grade=62,Major="CS"},
            //	new Student(){Name="Lina",Grade=88,Major="Math"},
            //	new Student(){Name="Huda",Grade=95,Major="CS"},
            //};

            //  Select S.name,S.grade
            // from Students S
            // where S.Grade > 80 && S.Major == "CS"

            //Query Syntax[Query Expression]
            // SQL like syntax , Must start with From Clause and end with Select or Group By Clause

            //var queryResult = from s in students  // S:range variable => each and every student in the students collection
            //				  where s.Grade > 80 && s.Major == "CS" // filtering condition
            //				  select new {s.Name, s.Grade }; //Select



            //foreach(var student in queryResult)
            //{
            //	Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            //}
            ////Method Syntax [Fluent Syntax]


            //Console.WriteLine("===========================");


            //var methodResult=students
            //	.Where(S=>S.Grade>=80&&S.Major=="CS")
            //	.Select(S => new { S.Name, S.Grade });

            //foreach (var student in methodResult)
            //{
            //	Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            //}
            #endregion

            #region Deferred vs Immediate Execution

            //var numbers = new List<int> { 1, 2, 3, 4, 5 };

            ////var result01 = numbers.Where(n => n % 2 == 0);


            //numbers.Add(6);


            ////foreach (var num in result01) // Execution Happens Here ,Because where is a deferred operator [Will wait until the result is printing]
            ////{
            ////	Console.WriteLine(num);  // Output: 2, 4, 6
            ////}



            //var numbers = new List<int> { 1, 2, 3, 4, 5 };

            //var result02 = numbers.Where(N => N % 2 == 0).ToList(); // Immediate Execution: Force Query to run rightnow regarding any change after


            //numbers.Add(6);

            //foreach (var num in result02) 
            //{
            //	Console.WriteLine(num);  
            //}







            // ===== Which operators are which? =====
            // Deferred:  operators that return IEnumerable<T>
            //            Where, Select, OrderBy, Take, Skip, Distinct ...
            // Immediate: operators that return a single value or a ready collection
            //            ToList, ToArray, ToDictionary, Count, Sum, Max, First, Single, Any ...
            #endregion

            #region Filtering - Restriction

            #region Where

            //// Out of stock products

            //var outOfStock=	ProductList.Where(P => P.UnitsInStock == 0); // FluentSyntax


            //	outOfStock=from P in ProductList
            //			   where P.UnitsInStock == 0
            //			   select P; // QuerySyntax


            //	foreach (var product in outOfStock)
            //	{
            //		Console.WriteLine(product);
            //	}





            //// In stock AND price > $20 — combine conditions with && (or ||)

            //var expensiveAndInStock=ProductList.Where(P=> P.UnitsInStock>0 &&P.UnitPrice>20); // FluentSyntax

            //expensiveAndInStock = from P in ProductList
            //					  where P.UnitsInStock > 0 && P.UnitPrice > 20
            //					  select P; // QuerySyntax


            //foreach (var product in expensiveAndInStock)
            //{
            //	Console.WriteLine(product);
            //}



            #endregion

            #region Indexed Where
            // Overload that also gives us the INDEX of each element (zero-based position in the source).
            // Available in method syntax ONLY — no query syntax equivalent.

            // Out of stock products among the first 20 products (index 0 → 19)

            //var outOfStockProductsAmong20 = ProductList.Where((P, I) => P.UnitsInStock == 0 && I < 20);




            //foreach (var product in outOfStockProductsAmong20)
            //{
            //	Console.WriteLine(product);
            //}

            #endregion

            #region OfType<>
            // Filters elements by their TYPE and returns IEnumerable<T>.
            // where Where() is not available because the elements are stored as object.

            //ArrayList mixed = new ArrayList() { 1, "hello", 3.14, "world", true, "lina" };


            //var strings = mixed.OfType<string>();  //keep strings Only ,Skip everytging else

            //foreach (var str in strings)
            //{
            //	Console.WriteLine(str);
            //}


            //var cast = mixed.Cast<string>();

            //foreach (var str in cast)
            //{
            //	Console.WriteLine(str);
            //}

            //System.InvalidCastException: 'Unable to cast object of type 'System.Int32' to typ


            //OffType vs Cast
            //OFFType : filter by runtime type and skip everything else
            // Cast : try to cast everything to the specified type and throw exception if it fails




            #endregion

            #endregion

            #region Projection

            #region Select

            //var productNames = ProductList.Select(P => P.ProductName);  // Projection : Select only the ProductName property from each product


            //productNames=from P in ProductList
            //			 select P.ProductName; // Query Syntax


            //foreach (var name in productNames)
            //{
            //	Console.WriteLine(name);
            //}


            //var productsWithBasicInfo = ProductList.Select(P => new { P.ProductName, P.Category, P.UnitPrice }); //Fluent Syntax

            //productsWithBasicInfo=from P in ProductList
            //					  select new { P.ProductName, P.Category, P.UnitPrice }; // Query Syntax

            //foreach (var product in productsWithBasicInfo)
            //{
            //	Console.WriteLine(product);
            //}

            // Indexed overload — also gives the zero-based index of each element.
            // Method syntax ONLY — no query syntax equivalent.


            //// InPlace = true when the number's value equals its position in the array

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7 };




            //var numbersInPlace = numbers.Select((n, index) => new { Num = n, InPlace = n == index });  // anynomous Object [num,INpLACE]

            //numbers[8] = 8;
            //foreach (var item in numbersInPlace)
            //{
            //	Console.WriteLine($"Num={item.Num}, InPlace={item.InPlace}");
            //}

            #endregion

            #region SelectMany
            // With Select: we get a collection of collections (one orders collection per customer)

            //var ordersPerCustomer = CustomerList.Select(C => C.Orders);

            //foreach(var CustomerOrders in ordersPerCustomer)

            //{
            //	foreach(var order in CustomerOrders)
            //	{
            //		Console.WriteLine(order);
            //	}
            //}			

            // With SelectMany: all orders flattened into ONE sequence
            // (customers with no orders simply produce nothing)


            //var allOrders = CustomerList.SelectMany(C => C.Orders);


            //foreach(var order in allOrders)
            //{
            //	Console.WriteLine(order);
            //}


            // SelectMany with result selector:
            // the second lambda receives BOTH the parent (c) and the child (o),
            // so we can keep customer data next to each order


            //var CustomerOrderInfo = CustomerList.SelectMany((C)=> C.Orders, (c, o) => new { c.CustomerID, o.OrderID, o.Total });

            //foreach (var item in CustomerOrderInfo)
            //{
            //	Console.WriteLine($"CustomerID={item.CustomerID}, OrderID={item.OrderID}, Total={item.Total:C2}");
            //}



            // Indexed SelectMany — ci is the customer's index


            //var customerOrdersWithIndex = CustomerList.SelectMany((c, ci) => c.Orders
            //.Select(o => $"Customer # {ci + 1} [{c.CustomerID}==>order Id:{o.OrderID}]"));

            //foreach(var order in customerOrdersWithIndex)
            //{
            //	Console.WriteLine(order);
            //}




            // Indexed on both levels — oi is the order's index and restarts from 0 for each customer


            //var customerOrdersWithIndex = CustomerList.SelectMany((c, ci) => c.Orders
            //															   .Select((o,oi) => $"Customer # {ci + 1} [{c.CustomerID}==>Order #{oi+1} order Id:{o.OrderID}]"));


            //foreach (var order in customerOrdersWithIndex)
            //{
            //	Console.WriteLine(order);
            //}


            // 1st overload : SelectMany() : 1 Func (1 Parameter )=> nested collection as Flat sequence
            // 2nd overload: SelectMany(,index) : 1 Func (2 Parameters) => nested Collection as Flat sequence
            // 3rd overload : SelectMany() : 2 Func [1st Func take one parameter and return flat sequence ],[2nd func(2 parameters) ] : keep customer with eaach order
            // 4rd overload: SelectMany() : 2 Func [1st Func take two parameter and return flat sequence ],[2nd func(2 parameters) ] : keep customer with eaach order along with Customer Inde

            // Query syntax: multiple 'from' clauses = SelectMany
            // Orders with Total < $500

            //var customerOrders = from c in CustomerList
            //					 from o in c.Orders
            //					 where o.Total < 500
            //					 select new { c.CustomerID, o.OrderID, o.Total };


            //foreach(var order in customerOrders)
            //	Console.WriteLine(order);


            // Same query in method syntax



            //var customerOrdersLessThan500 = CustomerList.
            //	SelectMany(c => c.Orders, (c, o) => new { c.CustomerID, o.OrderID, o.Total })
            //	.Where(o=>o.Total<500);




            //foreach (var order in customerOrdersLessThan500)
            //	Console.WriteLine(order);


            #endregion

            #endregion
            #endregion

            #region Session 02
            #region Ordering
            // Order()
            //var result = ProductList.Order();

            //foreach(var item in result)
            //    Console.WriteLine(item);

            // sort By Name
            //var result = ProductList.OrderBy(p => p.ProductName);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //sort from highest to lowest prices 

            //var result = ProductList.OrderByDescending(p => p.UnitPrice);

            //foreach (var item in result)
            //    Console.WriteLine(item);




            //========================Ordering With Comparrer============================
            ////The Second Parameter Controls How the keys are Compared====================
            ////Either Built In Comparers as string Comparers or user-defined one
            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRry", "ClOvEr", "cHeRry" };

            //////Default(no Comparer)==stringComparer.Current Culture +lingustic rule

            //var result = words.OrderBy(w => w);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            ////Oridnal Ignore Case :A=a but same output for these words

            //var result = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

            //foreach(var item in result)
            //    Console.WriteLine(item);

            //// Ordinal ===> compare Character Codes and Upper CASE fIRST
            //var result = words.OrderBy(w => w, StringComparer.Ordinal);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //// ============================Then By / Then By Descending=======================
            ////Secondary sort:applied Only between elements that are equal based on first criteria

            //// By Category anf Inside each category name
            //var result = ProductList.OrderBy(p => p.Category)
            //    .ThenBy(p => p.ProductName);



            //// By Category and Inside each Catgeory By Price (Highest First)
            //var result = ProductList
            //    .OrderBy(p => p.Category)
            //    .ThenByDescending(p=>p.UnitPrice);

            //foreach (var item in result)
            //    Console.WriteLine(item);



            //as a query Expression

            //var result = from p in ProductList
            //             orderby p.Category, p.UnitPrice descending
            //             select p;



            //foreach (var item in result)
            //    Console.WriteLine(item);





            ////==============================================Reverse=============================
            //// Doesn't Sort -just flips the current order of sequence [No Comparison]
            //// Method Syntax Only ---No Query Syntax

            //string[] names = { "Aya", "Omar", "Amr", "Mohamed", "Ahmed" };


            //var reversed = names.Reverse();

            //foreach(var item in reversed)
            //    Console.WriteLine(item);



            #endregion

            #region Element Operators-Method Syntax Only
            // First / FirstOrDefault / Last / LastOrDefault / Single / SingleOrDefault / ElementAt / ElementAtOrDefault

            #region First()-FirstOrDefault()
            // First as Position
            //var result = ProductList.First();
            //Console.WriteLine(result);

            //First product above 50 dollar using where
            //var result = ProductList.Where(p => p.UnitPrice > 50)
            //    .First();

            //First product above 50 dollar using First

            //var result = ProductList.First(p => p.UnitPrice > 50);
            //Console.WriteLine(result);
            // First product above 1500 dollar using First 
            //var result = ProductList
            //    .First(p => p.UnitPrice > 1500);
            //Console.WriteLine(result);

            //safe version
            //     var result = ProductList
            //.FirstOrDefault(new Models.Product() { ProductName = "NA" });
            //     //if ( result is null)
            //     //    Console.WriteLine("no product match");
            //     Console.WriteLine(result);
            #endregion

            #region Last() - LastOrDefault()
            // Last as Position
            // var result = ProductList.Last();
            //Console.WriteLine(result);


            //Last product above 50 dollar using where

            //var result = ProductList.Last(p => p.UnitPrice > 50);
            //Console.WriteLine(result);
            //First product above 50 dollar using Last

            // last product above 1500 dollar using Last 
            //var result = ProductList.Last(p => p.UnitPrice > 1500);
            //Console.WriteLine(result);            //var result = ProductList.Last(p => p.UnitPrice > 50);


            //safe version
            //var result = ProductList.LastOrDefault(p => p.UnitPrice > 1500);
            //Console.WriteLine(result);
            #endregion

            #region ElementAt() - ElementAtOrDefault()
            //Retreive 2nd element at products sequence
            //var result = ProductList.ElementAt(1);
            //Console.WriteLine(result);
            //Retreive 99th element at products sequence
            //var result = ProductList.ElementAt(99);
            //Console.WriteLine(result);
            //Safe
            //var result = ProductList.ElementAtOrDefault(99);
            //Console.WriteLine(result);


            //var result = ProductList.ElementAt(new Index(2, true));
            //Console.WriteLine(result);


            #endregion

            #region Single() -  SingleOrDefault()
            //retreive product and only product with Id=33
            //var result = ProductList.Single(p=>p.ProductID==33);
            //Console.WriteLine(result);

            //if there one and only product match condition, return it
            // if tehre are more than 1 element matching condition,throw ex
            //if there are no elements matching condition ,throw ex

            //Safe Version
            //var result = ProductList.SingleOrDefault(p => p.ProductID == 33);
            //Console.WriteLine(result);

            //if there one and only product match condition, return it
            // if tehre are more than 1 element matching condition,throw ex
            //if there are no elements matching condition ,throw ex
            #endregion
            #endregion

            #region Aggregate Operators - Method Syntax Only
            #region Count() - LongCount()
            //Retreive Number of elements in product sequence
            //var result = ProductList.Count();
            //Console.WriteLine(result);
            //Retreive Number of products out of stock

            //var result = ProductList.Count(p => p.UnitsInStock == 0);
            //Console.WriteLine(result);
            //LongCount:used when number of items exceed int range

            //var result = ProductList.LongCount(p => p.UnitsInStock == 0);
            //Console.WriteLine(result);
            #endregion

            #region Sum() - Average()

            //Retreive Total stock from products
            //var result = ProductList.Sum(p => p.UnitsInStock);
            //Console.WriteLine(result);

            //Retreive Average prices for Products
            //var result = ProductList.Average(p => p.UnitPrice);
            //Console.WriteLine(result);

            #endregion

            #region Max()-Min-MaxBy()-MinBy()
            ////Cheapist and Expensive prodcut price

            //var cheapest = ProductList.Min(p => p.UnitPrice);
            //Console.WriteLine(cheapest);

            //var expensive = ProductList.Max(p => p.UnitPrice);
            //Console.WriteLine(expensive);
            ////Cheapist and Expensive prodcut price [element it self]

            //var cheapest = ProductList.MinBy(p => p.UnitPrice);
            //Console.WriteLine(cheapest);
            //var expensive = ProductList.MaxBy(p => p.UnitPrice);
            //Console.WriteLine(expensive);
            #endregion

            #region Aggregate()
            //int[] nums = { 1, 2, 3, 4, 5 };


            //accumulate the product of above numbers to return single value
            //var result = nums.Aggregate((acc, n) => acc * n);
            //Console.WriteLine(result);


            // return first 5 producst accumulated with each other in single string

            //var result = ProductList.Take(5)
            //    .Select(p => p.ProductName)
            //    .Aggregate("", (acc, name) =>acc==""?name:$"{acc},{name}");   //,1stproduct,2ndproduct
            //Console.WriteLine(result);

            #endregion

            #endregion

            #region Quantifiers Operators
            ////Any Out Of STock Products
            //var result = ProductList.Any(p => p.UnitsInStock == 0);
            //Console.WriteLine(result);

            //All Seafood Products in  Stock

            //var result = ProductList
            //    .Where(p => p.Category == "Seafood")
            //    .All(p => p.UnitsInStock > 0);

            //Console.WriteLine(result);


            //Contains Number 4

            //int[] nums = [2, 3, 4, 5];

           // Console.WriteLine($"Contain(4)? {nums.Contains(4)}");
            //Console.WriteLine($"Contain(4)? {nums.Contains(9)}");



            #endregion

            #region Partitoning Operators
           // int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region Take() - Skip()
            //First 3 Numbers
            //var result = numbers.Take(3);
            //foreach(var item in result)
            //    Console.WriteLine(item);

            //First 5 products By Price Desc
            //var result = ProductList
            //    .OrderByDescending(p => p.UnitPrice)
            //    .Take(5);


            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Skip First 4 elements

            //var result = numbers.Skip(4);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region TakeWhile() - SkipWhile()
            //Take while numbers Less Than 6
            //var result = numbers
            //    .TakeWhile(N => N < 6);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Take while value>=Position
            //var result = numbers.TakeWhile((n, i) => n >= i);

            //foreach (var item in result)
            //    Console.WriteLine(item);


            //Skip untill divisble by 3
            //var result = numbers.SkipWhile(n => n % 3 != 0);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            // Skip While value>=pos

            //var result = numbers.SkipWhile((n, i) => n >= i);

            //foreach (var item in result)
            //    Console.WriteLine(item);
            #endregion

            #region Hybrid Syntax [Query+Method]
            //var result = (from p in ProductList
            //              orderby p.UnitPrice descending
            //              select p).Take(5);
            #endregion
            #endregion

            #region Set Operators
            #region Distinct() - DistinctBy()

            //Retreive unique Categories Names
            //var result = ProductList.
            //    Select(p => p.Category)
            //    .Distinct();

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //string[] dup = { "apple", "Apple", "APPLE", "cherry", "Cherry" };


            //var result = dup.Select(d => d)
            //    .Distinct(StringComparer.OrdinalIgnoreCase);


            //foreach (var item in result)
            //    Console.WriteLine(item);

            //remove duplicates with considering apple=Apple


            #endregion

            #region Union()-Intersect()-Except()
            //int[] a = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] b = { 1, 3, 5, 7, 8 };

            string[] list1 = { "apple", "bannana", "cherry" };
            string[] list2 = { "Apple", "GRAPE", "CHERRY" };

            #region Union

            //Retreive combination of a ,b with remove duplicates

            //var result = a.Union(b);


            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Retreive first letter of products combined with first letter of customer with remove duplicates

            //var result = ProductList.Select(p => p.ProductName[0].ToString())
            //    .Union(CustomerList.Select(c => c.CustomerName[0].ToString()), StringComparer.OrdinalIgnoreCase);


            //foreach (var item in result)
            //    Console.WriteLine(item);
            #endregion

            #region Intersect
            //Retrieve the matched data between a,b
            //var result = a.Intersect(b);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Retreive intersection between 2 string lists with ignoring senstivity
            //var result = list1.Intersect(list2, StringComparer.OrdinalIgnoreCase);

            //foreach (var item in result)
            //    Console.WriteLine(item);
            #endregion

            #region Except
            //Retreive the difference between a,b
            //var result = a.Except(b);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Retreive difference between 2 string lists with ignoring senstivity
            //var result = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

            //foreach (var item in result)
            //    Console.WriteLine(item);
            #endregion
            #endregion
            #endregion

            #region Let and Into Keywords [Valid with Query Expressions Only]
            //let :Save Value as temp variable
            //retreive products that its 90% less than 20 dollar
            //var result = from p in ProductList
            //             where p.UnitPrice * 0.9m < 20
            //             select new
            //             {
            //                 p.ProductName,
            //                 p.UnitPrice,
            //                 PriceAfterDiscount = p.UnitPrice * 0.9m
            //             };


            //foreach (var item in result)
            //    Console.WriteLine(item);


            //var result = from p in ProductList
            //             let priceAfterDisc= p.UnitPrice * 0.9m
            //             where priceAfterDisc < 20
            //             select new
            //             {
            //                 p.ProductName,
            //                 p.UnitPrice,
            //                 PriceAfterDiscount =priceAfterDisc
            //             };


            //foreach (var item in result)
            //    Console.WriteLine(item);






            // into: restart query expression
            // needed to filter groups 
            //save result of any query till select and group by


            //retreive product Prices After Slecting its discount 90%
            //var result = from p in ProductList
            //             select p.UnitPrice * 0.9m
            //           into priceAfterDisc
            //             where priceAfterDisc < 20
            //             select priceAfterDisc;


            //foreach (var item in result)
            //    Console.WriteLine(item);


            #endregion

            #region Grouping Operators
            #region Example 01
            //Retrieves all products from ProductList That Out Of Stock , and groups the products by their Category
            //var result = ProductList
            //    .Where(p => p.UnitsInStock == 0)
            //    .GroupBy(p => p.Category);


            //foreach(var group in result)
            //{
            //    Console.WriteLine($"category:{group.Key}--Count of Products:{group.Count()}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }

            //    Console.WriteLine("======================");
            //}


            //as query expression

            //var result = from p in ProductList
            //             where p.UnitsInStock == 0
            //             group p by p.Category;

            //foreach (var group in result)
            //{
            //    Console.WriteLine($"category:{group.Key}--Count of Products:{group.Count()}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }

            //    Console.WriteLine("======================");
            //}


            #endregion

            #region Example 02
            // Retrieves all products from ProductList That Out of Stock
            // Groups the products by their Category.
            // Filters out categories that contain 2 or fewer products.
            // Returns an anonymous object with two properties:
            // CategoryName 
            // CountOfProducts → the number of products in that category.


            //var result = ProductList
            //    .Where(p => p.UnitsInStock == 0)
            //    .GroupBy(p => p.Category)
            //    .Where(g => g.Count() <= 2)
            //    .Select(g => new
            //    {
            //        Category = g.Key,
            //        CountOfProducts = g.Count()

            //    });


            //var result = from p in ProductList
            //             where p.UnitsInStock == 0
            //             group p by p.Category
            //           into category
            //             where category.Count() <= 2
            //             select new
            //             {
            //                 Category = category.Key,
            //                 CountOfProducts = category.Count()
            //             };



            //foreach (var group in result)
            //    Console.WriteLine(group);






            //as query expression





            #endregion

            #region Example 03
            //Group words by first letter(case -insensitive)
            //string[] w = { "Apple", "banana", "Avocado", "Berry", "Cherry", "apricot" };
            //// A b B C a

            //var result = w.GroupBy(s => s[0].ToString(), StringComparer.OrdinalIgnoreCase);

            //foreach(var group in result)
            //{
            //    Console.WriteLine($"Letter : '{group.Key}'------{group.Count()} words");
            //}
            #endregion

            #endregion

            #region Generation Operators
            //generate sequence from 1 and 10 steps then
            //var result = Enumerable.Range(1, 10);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //generate sequenve from 0 and 5 steps then,and project it as a number multipled by itself
            //var result = Enumerable.Range(0, 5).
            //    Select(n => n * n);


            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Repeat hello 4 times
            //var result = Enumerable.Repeat("Hello", 4);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //Generate empty sequence of product
            // var result = Enumerable.Empty<Product>();



            //uses it with defaultIfEmpty
            #endregion

            #region Casting Operators
            //// ToArray / ToList / ToDictionary / Cast 



            //make array of product Names

            //var result = ProductList.Select(p => p.ProductName).ToArray();


            //Console.WriteLine(result[0]);

            //Make list of products in seafood category
            //var result = ProductList.Where(p => p.Category == "Seafood").ToList();



            //Make dictionary of products based on Id as key

            //var result = ProductList.ToDictionary(p=>p.ProductID);

            //Console.WriteLine(result[75]);
            //Make dictionary of products based on Id as key and name only as a value

            //var result = ProductList.ToDictionary(p => p.ProductID,p=>p.ProductName);
            //Console.WriteLine(result[75]);



            //Cast

            //ArrayList al = new() { 1, "Khaled", 3, 4, 5 };

            //var result = al.Cast<int>();


            //foreach (var item in result)
            //    Console.WriteLine(item);




            #endregion

            #region Sequence Operators
            //int[] a = { 1, 2, 3 };
            //int[] b = { 3, 4, 5 };


            //Concat a,b
            //var result = a.Concat(b);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            // Zip a,b as new sequence product of a element and its opposite b element


            //var result = a.Zip(b);

            //foreach (var item in result)
            //    Console.WriteLine(item);

            //var result = a.Zip(b, (a, b) => a * b);

            //foreach (var item in result)
            //    Console.WriteLine(item);
            int[] x1 = { 1, 2, 3 };
            int[] x2 = { 1, 2, 3 };
            int[] x3 = { 1, 2, 4 };

            //Check that x1 and x2 is equals in values and order

            //Check that x1 and x3 is equals in values and order




            //string[] s1 = { "Apple", "Banana" };
            //string[] s2 = { "apple", "BANANA" };

            //Check s1 and s2 equal in value and order with ignoring senstivity

            #endregion
            #endregion
        }
    }
}
