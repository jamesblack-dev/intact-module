Here is my submission for the Highest Word Frequency module.

I would also suggest modification to the interface to allow for reuse of the sorted list and hashmap object, as current implementation dictates that it is generated on every method call.
With more research the code can be more performant, as it is the algorithm provided is O(n) which seemed an appropriate for the provided test data.
With more time I would add performance testing test cases to verify the performance of the methods under test.
Some defensive programming I would like to add is to verify the found result is not null, and other null checking on the methods, with test cases to further verify correctness.
I used these versions of libraries as these are what I'm most familiar with.
