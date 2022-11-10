/*
List<(string,string)> ToDo;
ToDo = new List<(string, string)>();
new Tuple <(string,string)>("beans", "cats");

for(int x =0; x<=ToDo.Count; x++)
{
    Console.WriteLine(ToDo[x]);
}
*/

Console.Clear();
List<(string, string, DateTime)> StartingTasks = new List<(string, string, DateTime)>();
Console.WriteLine("Hello Client, here is your Task Management system.");
DateTime StartTime = new DateTime();
List<(string, string, DateTime, DateTime)> CompleteTasks = new List<(string, string, DateTime, DateTime)>();
DateTime CompletionTime = new DateTime();
int TasksCreated = 0;
int TasksRemoved = 0;
int TasksCompleted = 0;


void ToDoItems(){
    Console.WriteLine("Here are your incomplete items");
    for(int x = 0; x <StartingTasks.Count; x++){
        Console.WriteLine($" {x + 1}: {StartingTasks[x]}");
    }
    if(StartingTasks.Count == 0)
    Console.WriteLine("You currently have no items on your list");
    Console.ReadLine();
    TaskMenu();
}

void CompletedTasks(){
    Console.WriteLine("Here are your Completed Tasks");
    for(int x = 0; x < CompleteTasks.Count; x++){
    Console.WriteLine($" {x + 1}: {CompleteTasks[x]}");
    }
    if(CompleteTasks.Count == 0)
    Console.WriteLine("You currently have no items on your list");
    Console.ReadLine();
    TaskMenu();
}

void RemoveTasks(){
    Console.WriteLine("Which Task would you like to remove?");

    for(int x = 0; x <StartingTasks.Count; x++){
        Console.WriteLine($" {x + 1}: {StartingTasks[x]}");
    }
    Console.WriteLine("(Type the Number)");
    int NumComp = int.Parse(Console.ReadLine()) - 1;
    if(NumComp > StartingTasks.Count){
        Console.WriteLine("Invalid Input");
        TaskMenu();
    }
    Console.WriteLine($"Is this the Task that you want to Remove {StartingTasks[NumComp]}\n<y or n>");
    string response = Console.ReadLine();
    if(response == "y"){
        Console.WriteLine("Okay, Item removed");
        StartingTasks.Remove(StartingTasks[NumComp]);
        TasksRemoved++;
        TaskMenu();
    }
    if(response == "n"){
        Console.WriteLine("Okay, sounds good");
        TaskMenu();
    }
    Console.ReadLine();
    TaskMenu();
}

void CompletingTasks(){
    Console.WriteLine("Which Task would you like to complete?");
    for(int x = 0; x <StartingTasks.Count; x++){
        Console.WriteLine($" {x + 1}: {StartingTasks[x]}");
    }
    Console.WriteLine("(Type the Number)");
    int NumComp = int.Parse(Console.ReadLine()) - 1;
    if(NumComp > StartingTasks.Count){
        Console.WriteLine("Invalid Input");
        TaskMenu();
    }
    Console.WriteLine($"Is this the Task that you want to Complete {StartingTasks[NumComp]}\n<y or n>");
    string response = Console.ReadLine();
    if(response == "y"){
        Console.WriteLine("Okay, Item Completed");
        (string, string, DateTime) TaskCompleted = StartingTasks[NumComp];
        CompletionTime = DateTime.Now;
        StartingTasks.Remove(StartingTasks[NumComp]);
        CompleteTasks.Add((TaskCompleted.Item1,TaskCompleted.Item2, TaskCompleted.Item3, CompletionTime));
        TasksCompleted++;
        TaskMenu();
    }
    if(response == "n"){
        Console.WriteLine("Okay, sounds good");
        TaskMenu();
    }


    TaskMenu();
}

void Stats(){
    Console.WriteLine("Here are your stats.");
    Console.WriteLine($"Tasks Created: {TasksCreated} \nTasks Completed: {TasksCompleted} \nTasks Removed: {TasksRemoved}");
    Console.ReadLine();
    TaskMenu();
}

void AddingItems(){
        Console.WriteLine("Which item would you like to add?");
        string response = Console.ReadLine();
        string Task = response;
        Console.WriteLine($"Here is the name of the item: {Task}");
        Console.WriteLine("What is the description?");
        response = Console.ReadLine();
        string Description = response;
        Console.WriteLine($"Here is the task: {Task}: {Description}");
        Console.WriteLine("Is this what you want?\n<y or n>");
        response = Console.ReadLine();
        if(response == "y"){
            Console.WriteLine("Okay, Item Added");
            StartTime = DateTime.Now;
            (string, string, DateTime) TaskToBeDone = (Task, Description, StartTime);
            StartingTasks.Add(TaskToBeDone);
            TasksCreated++;
            TaskMenu();
        }
        if(response == "n"){
            Console.WriteLine("Okay, Sounds Good");
            TaskMenu();
        }
    }

void TaskMenu(){
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1) See tasks to be done\n2) See Completed Tasks\n3) Add Items\n4) Remove Tasks\n5) Complete Tasks\n6) See Stats\n7) Be Done");
    string response = Console.ReadLine();
    if(response == "1")
        ToDoItems();
    if(response == "2")
        CompletedTasks();
    if(response == "3")
        AddingItems();
    if(response == "4")
        RemoveTasks();
    if(response == "5")
        CompletingTasks();
    if(response == "6")
        Stats();
    if(response == "7")
        System.Environment.Exit(0);
    else{
        TaskMenu();
    }
}
TaskMenu();

