# Pyramid Challenge

The program takes one argument - a path to a file with the input data. It calculates which path from top to bottom of the pyramid has the largest sum, and prints on output both the optimal path and the sum.

An additional constaint is applied: path can only alternate between even and odd numbers. I have assumed that there is always at least one such a path. I have also assumed that numbers are also positive (which wasn't stated in the task, but was true for the example and task).

## Running the program

I assume the user is in the root directory of the project.

```
cd pyramid-challenge
dotnet run .\resources\task.txt
```

### Testing the program

```
cd ..
dotnet test
```