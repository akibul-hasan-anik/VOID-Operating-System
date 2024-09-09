using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;
        string current_directory = "0:\\";

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Welcome to VOID() Operating System\n\n");
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        protected override void Run()
        {
            string input;
            input = Console.ReadLine();
            if (input == "help")
            {
                Console.WriteLine("***basic***\nabout\ndate\ntime\nday\nclear\ncalculator\nshutdown\n\n***file***\ncreate_file\nwrite_file\nappend_file\nshow_file\ndelete_file\nlist_file\n\n***directory***\ncreate_directory\ncurrent_directory\nchange_directory\nlist_directory\ndelete_directory\nback\n\n***scheduling***\nfcfs\nsjf\n\n***memory_management***\nfirst_fit\nbest_fit\nworst_fit");
            }
            if (input == "about")
            {
                Console.WriteLine("VOID() Operating System Version 0.0\n");
            }
            if (input == "date")
            {
                string date = DateTime.Now.ToString("dd/mm/yyyy\n");
                Console.WriteLine(date);
            }
            if (input == "time")
            {
                string time = DateTime.Now.ToString("hh:mm:ss\n");
                Console.WriteLine(time);
            }
            if (input == "day")
            {
                string day = DateTime.Now.ToString("dddd\n");
                Console.WriteLine(day);
            }
            if (input == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            if (input == "create_file")
            {
                Console.WriteLine("Enter the file name :");
                string fileName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(fileName))
                    {
                        throw new ArgumentException("Please provide a valid filename.\n");
                    }
                    // Append .txt extension if not provided by the user
                    if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        fileName += ".txt";
                    }
                    // Get the full path (adjust base path if needed)
                    string filePath = Path.Combine(current_directory, fileName);
                    // Check if the file already exists
                    if (File.Exists(filePath))
                    {
                        Console.WriteLine($"'{fileName}' already exists.\n");
                        return;
                    }
                    // Create the file
                    using (FileStream fileStream = File.Create(filePath))
                    {
                        Console.WriteLine($"{fileName} created successfully!\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating file: {ex.Message}");
                }
            }
            if (input == "list_file")
            {
                try
                {
                    // Get the files in the current directory
                    string[] files = Directory.GetFiles(current_directory);
                    // Display the list of files
                    Console.WriteLine("Files in the current directory:");
                    foreach (string file in files)
                    {
                        Console.WriteLine(Path.GetFileName(file));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error listing files: {ex.Message}\n");
                }
                Console.WriteLine("\n");
            }
            if (input == "delete_file")
            {
                Console.WriteLine("Enter the file name :");
                string fileName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(fileName))
                    {
                        throw new ArgumentException("Please provide a valid filename.");
                    }
                    // Append .txt extension if not provided by the user
                    if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        fileName += ".txt";
                    }
                    // Get the full path (adjust base path if needed)
                    string filePath = Path.Combine(current_directory, fileName);
                    // Check if the file exists
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"{fileName} does not exist.\n");
                        return;
                    }
                    // Delete the file
                    File.Delete(filePath);
                    Console.WriteLine($"{fileName} deleted successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting file: {ex.Message}");
                }
            }
            if (input == "write_file")
            {
                Console.WriteLine("Enter the file name :");
                string fileName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(fileName))
                    {
                        throw new ArgumentException("Please provide a valid filename.\n");
                    }
                    // Append .txt extension if not provided by the user
                    if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        fileName += ".txt";
                    }
                    // Get the full path (adjust base path if needed)
                    string filePath = Path.Combine(current_directory, fileName);
                    // Check if the file exists
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"{fileName} does not exist. Please create the file first.\n");
                        return;
                    }
                    // Prompt the user to enter the text to write to the file
                    Console.WriteLine("Enter the text to write to the file:");
                    string fileContent = Console.ReadLine();
                    // Write the content to the file
                    File.WriteAllText(filePath, fileContent);
                    Console.WriteLine($"Content written to '{fileName}' successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}\n");
                }
            }
            if (input == "show_file")
            {
                Console.WriteLine("Enter the file name :");
                string fileName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(fileName))
                    {
                        throw new ArgumentException("Please provide a valid filename.\n");
                    }
                    // Append .txt extension if not provided by the user
                    if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        fileName += ".txt";
                    }
                    // Get the full path (adjust base path if needed)
                    string filePath = Path.Combine(current_directory, fileName);
                    // Check if the file exists
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"{fileName} does not exist.\n");
                        return;
                    }
                    // Read the content of the file and display it
                    string fileContent = File.ReadAllText(filePath);
                    Console.WriteLine($"Content of '{fileName}':");
                    Console.WriteLine(fileContent);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error displaying file content: {ex.Message}\n");
                }
            }
            if (input == "append_file")
            {
                Console.WriteLine("Enter the file name :");
                string fileName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(fileName))
                    {
                        throw new ArgumentException("Please provide a valid filename.\n");
                    }
                    // Append .txt extension if not provided by the user
                    if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        fileName += ".txt";
                    }
                    // Get the full path (adjust base path if needed)
                    string filePath = Path.Combine(current_directory, fileName);
                    // Check if the file exists
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"{fileName} does not exist. Please create the file first.\n");
                        return;
                    }
                    // Prompt the user to enter the text to append
                    Console.WriteLine("Enter the text to append:");
                    string appendedText = Console.ReadLine();
                    // Append the text to the file
                    File.AppendAllText(filePath, appendedText);
                    Console.WriteLine($"Text appended to '{fileName}' successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error appending text to file: {ex.Message}\n");
                }
            }

            if (input == "clear")
            {
                Console.Clear();
            }
            if (input == "calculator")
            {
                Console.WriteLine("Enter 'add' for addition\nEnter 'sub' for subtraction\nEnter 'mul' for multiplication\nEnter 'div' for division\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "add":
                        Addition();
                        break;
                    case "sub":
                        Subtraction();
                        break;
                    case "mul":
                        Multiplication();
                        break;
                    case "div":
                        Division();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!\n");
                        break;
                }

                static void Addition()
                {
                    Console.Write("Enter the first number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the second number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    double result = num1 + num2;
                    Console.WriteLine($"Result: {result}\n");
                }

                static void Subtraction()
                {
                    Console.Write("Enter the first number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the second number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    double result = num1 - num2;
                    Console.WriteLine($"Result: {result}\n");
                }

                static void Multiplication()
                {
                    Console.Write("Enter the first number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the second number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    double result = num1 * num2;
                    Console.WriteLine($"Result: {result}\n");
                }

                static void Division()
                {
                    Console.Write("Enter the dividend: ");
                    double dividend = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the divisor (non-zero): ");
                    double divisor = Convert.ToDouble(Console.ReadLine());

                    if (divisor == 0)
                    {
                        Console.WriteLine("Error: Division by zero!\n");
                        return;
                    }

                    double result = dividend / divisor;
                    Console.WriteLine($"Result: {result} \n");
                }
            }


            if (input == "create_directory")
            {
                Console.WriteLine("Enter the directory name :");
                string directoryName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(directoryName))
                    {
                        throw new ArgumentException("Please provide a valid folder name.");
                    }

                    // Combine folder name with current directory path
                    string folderPath = Path.Combine(current_directory, directoryName);

                    // Check if the folder already exists
                    if (Directory.Exists(folderPath))
                    {
                        Console.WriteLine($"Folder '{directoryName}' already exists.\n");
                        return;
                    }

                    // Create the folder
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"Folder '{directoryName}' created successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating folder: {ex.Message}");
                }
            }
            if (input == "list_directory")
            {

                try
                {
                    // Get directories in the specified directory
                    string[] directories = Directory.GetDirectories(current_directory);

                    // Display the list of directories
                    Console.WriteLine("Directories in the current directory:");
                    foreach (string dir in directories)
                    {
                        Console.WriteLine(Path.GetFileName(dir));
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error listing directories: {ex.Message}\n");
                }
            }
            if (input == "change_directory")
            {
                Console.WriteLine("Enter the directory name :");
                string directoryName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(directoryName))
                    {
                        throw new ArgumentException("Please provide a valid directory name.");
                    }

                    // Combine directory name with current directory path
                    string newDirectoryPath = Path.Combine(current_directory, directoryName);

                    // Check if the directory exists
                    if (!Directory.Exists(newDirectoryPath))
                    {
                        Console.WriteLine($"Directory '{directoryName}' does not exist.\n");
                        return;
                    }

                    // Update current directory to the specified directory
                    current_directory = newDirectoryPath;
                    Console.WriteLine($"Navigated to directory '{directoryName}' successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error navigating to directory: {ex.Message}");
                }
            }
            if (input == "delete_directory")
            {
                Console.WriteLine("Enter the directory name :");
                string directoryName = Console.ReadLine();
                try
                {
                    // Validate user input
                    if (string.IsNullOrEmpty(directoryName))
                    {
                        throw new ArgumentException("Please provide a valid directory name.");
                    }

                    // Combine directory name with current directory path
                    string directoryPath = Path.Combine(current_directory, directoryName);

                    // Check if the directory exists
                    if (!Directory.Exists(directoryPath))
                    {
                        Console.WriteLine($"Directory '{directoryName}' does not exist.\n");
                        return;
                    }

                    // Delete the directory
                    Directory.Delete(directoryPath, true); // Set recursive to true to delete all subdirectories and files
                    Console.WriteLine($"Directory '{directoryName}' deleted successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting directory: {ex.Message}");
                }
            }
            if (input == "back")
            {
                try
                {
                    // Get the parent directory path
                    string parentDirectory = Directory.GetParent(current_directory)?.FullName;

                    // Check if the current directory is already the root directory
                    if (parentDirectory == null || parentDirectory == current_directory)
                    {
                        Console.WriteLine("Already at the root directory.\n");
                        return;
                    }

                    // Update current directory to the parent directory
                    current_directory = parentDirectory;
                    Console.WriteLine("Navigated back to the parent directory.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error navigating back: {ex.Message}");
                }
            }
            if (input == "current_directory")
            {
                try
                {
                    // Display the current directory
                    Console.WriteLine($"Current Directory: {current_directory}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error displaying current directory: {ex.Message}");
                }
            }
            if (input == "fcfs")
            {
                int process;
                int[] arrival = new int[100];
                int[] burst = new int[100];

                Console.WriteLine("\nYou have selected the FCFS");
                Console.Write("Enter the number of processes : ");
                process = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the arrival time and burst time : ");
                for (int i = 1; i <= process; i++)
                {
                    Console.Write($"Process[{i}] : ");
                    string[] inputs = Console.ReadLine().Split(' ');
                    arrival[i] = int.Parse(inputs[0]);
                    burst[i] = int.Parse(inputs[1]);
                }
                int[] waiting_time = new int[100];
                int[] turnaround_time = new int[100];
                int[] response_time = new int[100];
                int total_waiting_time = 0;
                burst[0] = 0;
                waiting_time[0] = 0;
                turnaround_time[0] = 0;
                Console.WriteLine("Process\t\tWaiting_time\t\tTurnaround_time\t\tResponse_time");
                for (int i = 1; i <= process; i++)
                {
                    waiting_time[i] = waiting_time[i - 1] + burst[i - 1];
                    turnaround_time[i] = waiting_time[i] + burst[i];
                    response_time[i] = waiting_time[i];
                    total_waiting_time += waiting_time[i];
                    Console.WriteLine($"{i}\t\t\t\t\t{waiting_time[i]}\t\t\t\t\t{turnaround_time[i]}\t\t\t\t\t{response_time[i]}");
                }
                float avg_waiting_time = (float)total_waiting_time / process;
                Console.WriteLine($"Average waiting time : {avg_waiting_time:F2}\n");
            }

            if (input == "sjf")
            {
                int process;
                int[] arrival = new int[100];
                int[] burst = new int[100];

                Console.WriteLine("\nYou have selected the SJF\n");
                Console.Write("Enter the number of processes : ");
                process = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the arrival time and burst time : ");
                for (int i = 1; i <= process; i++)
                {
                    Console.Write($"Process[{i}] : ");
                    string[] inputs = Console.ReadLine().Split(' ');
                    arrival[i] = int.Parse(inputs[0]);
                    burst[i] = int.Parse(inputs[1]);
                }

                // Sort processes based on burst time (ascending order)
                for (int i = 1; i <= process; i++)
                {
                    for (int j = i + 1; j <= process; j++)
                    {
                        if (burst[i] > burst[j])
                        {
                            int temp_burst = burst[i];
                            burst[i] = burst[j];
                            burst[j] = temp_burst;
                            int temp_arrival = arrival[i];
                            arrival[i] = arrival[j];
                            arrival[j] = temp_arrival;
                        }
                    }
                }

                // SJF logic
                int[] waiting_time = new int[100];
                int[] turnaround_time = new int[100];
                int[] response_time = new int[100];
                int total_waiting_time = 0;
                burst[0] = 0;
                waiting_time[0] = 0;
                turnaround_time[0] = 0;
                Console.WriteLine("Process\t\tWaiting_time\t\tTurnaround_time\t\tResponse_time");
                for (int i = 1; i <= process; i++)
                {
                    waiting_time[i] = waiting_time[i - 1] + burst[i - 1];
                    turnaround_time[i] = waiting_time[i] + burst[i];
                    response_time[i] = waiting_time[i];
                    total_waiting_time += waiting_time[i];
                    Console.WriteLine($"{i}\t\t\t\t\t{waiting_time[i]}\t\t\t\t\t{turnaround_time[i]}\t\t\t\t\t{response_time[i]}");
                }
                float avg_waiting_time = (float)total_waiting_time / process;
                Console.WriteLine($"Average waiting time : {avg_waiting_time:F2}\n");
            }

            if (input == "first_fit")
            {
                int[] m = { 100, 500, 200, 300, 600 };
                int[] p = { 212, 417, 112, 426 };
                bool[] track = { false, false, false, false };

                Console.WriteLine("First-Fit");

                for (int i = 0; i < p.Length; i++)
                {
                    for (int j = 0; j < m.Length; j++)
                    {
                        if (p[i] <= m[j])
                        {
                            Console.WriteLine($"p{i}={p[i]}K put in {m[j]}K partition");
                            m[j] -= p[i];
                            track[i] = true;
                            break;
                        }
                    }
                }

                for (int i = 0; i < p.Length; i++)
                {
                    if (!track[i])
                    {
                        Console.WriteLine($"p{i}={p[i]}K can't be placed");
                    }
                }

            }

            if (input == "worst_fit")
            {
                static void SortDescending(int[] arr)
                {
                    int n = arr.Length;
                    for (int i = 0; i < n - 1; i++)
                    {
                        for (int j = 0; j < n - i - 1; j++)
                        {
                            if (arr[j] < arr[j + 1])
                            {
                                int temp = arr[j];
                                arr[j] = arr[j + 1];
                                arr[j + 1] = temp;
                            }
                        }
                    }
                }
                int[] m = { 100, 500, 200, 300, 600 };
                int[] p = { 212, 417, 112, 426 };
                bool[] track = new bool[p.Length];

                SortDescending(m);

                for (int i = 0; i < p.Length; i++)
                {
                    track[i] = false;
                }

                Console.WriteLine("Worst-Fit");

                for (int i = 0; i < p.Length; i++)
                {
                    for (int j = 0; j < m.Length; j++)
                    {
                        if (p[i] <= m[j])
                        {
                            Console.WriteLine($"p{i}={p[i]}K put in {m[j]}K partition");
                            m[j] -= p[i];
                            track[i] = true;
                            break;
                        }
                    }
                }
                for (int i = 0; i < p.Length; i++)
                {
                    if (!track[i])
                    {
                        Console.WriteLine($"p{i}={p[i]}K can't be placed");
                    }
                }
            }
            if (input == "best_fit")
            {
                static int Min(int[] a, int n)
                {
                    int minimum = int.MaxValue;
                    for (int i = 0; i < n; i++)
                    {
                        if (minimum > a[i])
                        {
                            minimum = a[i];
                        }
                    }
                    return minimum;
                }
                int[] m = { 100, 500, 200, 300, 600 };
                int[] p = { 212, 417, 112, 426 };
                bool[] track = new bool[p.Length];
                int[] stack = new int[10];
                int top, l;

                Console.WriteLine("Best-Fit");

                for (int i = 0; i < p.Length; i++)
                {
                    track[i] = false;
                }

                for (int i = 0; i < p.Length; i++)
                {
                    top = 0;
                    for (int j = 0; j < m.Length; j++)
                    {
                        if (p[i] <= m[j])
                        {
                            stack[top] = m[j];
                            top++;
                        }
                    }

                    if (top > 0)
                    {
                        l = Min(stack, top);
                        for (int j = 0; j < m.Length; j++)
                        {
                            if (l == m[j])
                            {
                                Console.WriteLine($"p{i}={p[i]}K put in {m[j]}K partition");
                                m[j] -= p[i];
                                track[i] = true;
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < p.Length; i++)
                {
                    if (!track[i])
                    {
                        Console.WriteLine($"p{i}={p[i]}K can't be placed");
                    }
                }
            }
        }
    }
}
