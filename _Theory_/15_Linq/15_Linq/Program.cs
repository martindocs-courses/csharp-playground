/* Navigation Notes
         
    LINQ                                                                  : line 12
    Relation between LINQ and IEnumerable interface                       : line 
    Feature of LINQ                                                       : line
    Deferred execution                                                    : line 
    Lambda expression                                                     : line
    LINQ methods                                                          : line
    - Any                                                                 : line
    - All                                                                 : line
    - Count & LongCount                                                   : line
    - Contains                                                            : line
    - OrderBy, OrderByDesending, ThenBy, ThenByDesending                  : line
    - First & Last                                                        : line
    - FirstOrDefault & LastOrDefault                                      : line
    - Where                                                               : line
    - Distinct                                                            : line
    - Select                                                              : line
    - Anonymous Types                                                     : line

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    LINQ (Language Integrated Query) is a set of technologies that allow simple and efficient querying over different kinds of data.
*/

/* RELATION BETWEEN LINQ and IEnumerable (refer to practice example 2) */

/*
    - IEnumerable<T> of T is an interface implemented by most of the C# collections. Arrays, lists, HashSets and Dictionaries all implement it. <T>  means any type.

    - IEnumerable doesn't expose any methods for collection modification. That means LINQ methods will never modify the input collections because they simply don't have the means to do so. There are no methods for collection modification in the IEnumerable of T interface that LINQ could use to modify a collection. 
      The original collection will not be modified and only new collection with an extra element will be created. 
 */

/* FEATURE OF LINQ (refer to practice example 3) */
// Most of the LINQ methods take IEnumerable<T> as a parameter and they return IEnumerable<T>as a result. The input and the output have the same type. That means we can execute a LINQ method on the result that another LINQ method produced (aka. chaining the methods)

/* DEFERRED EXECUTION (refer to practice example 4) */
/* 
    * Deferred execution means that the evaluation of a LINQ expression is delayed until the value is actually needed.
    * It allows work on the latest data.
    * It improves performance by avoiding unnecessary execution. The query is materialized only when is need it.  
    * One of the method we can use to force materialization of the LINQ query into a collection is ToList()
*/

/* LAMBDA EXPRESSION */
// lambda expression is simply an anonymous function.

/* LINQ METHODS */
// ANY (return bool) - is used to check if any element in the collection matches the given criteria. 

// All (return bool) - checks if any element in the collection met the given criteria. All checks if all elements do.

// COUNT & LONGCOUNT (return int / long) - count the elements of the collection that match some given predicate.

// CONTAINS (return bool) - checks if a given element is present in the collection.

// ORDERBY (return IEnumerable<T>) - the collection by some criteria.

// FIRST & LAST (return First/Last element, or throws if empty ) - returns the first element from the collection. If a predicate is given, it returns the first element that matches this predicate. The last method works the same, but it returns the last element.

// FIRSTORDEFAULT & LASTORDEFAULT (Returns element or default (null/0/etc.)) - they will return the default value for the type stored in the collection if there is no first or last element that matches the given criteria.

// WHERE (return IEnumerable<T>) - filters the collection based on a predicate.

// DISTINCT (return IEnumerable<T>) - removes all duplicated values from the collection, returning a collection of unique elements.

// SELECT (return IEnumerable<T>) - projects each element of a collection into a new form. This means that with the lambda expression, we define an operation that will be applied to each element of the collection. The aggregated results of those operations will create a new collection.

// ANONYMOUS TYPES - types without names. They are typically used when we need to create objects, having some specific set of properties, but if we don't want to define a dedicated type for them because we don't intend to use this type anywhere else. Anonymous type objects are created using object initializer that contain the list of properties and their values. LINQ queries are the places where the anonymous types are most often used.