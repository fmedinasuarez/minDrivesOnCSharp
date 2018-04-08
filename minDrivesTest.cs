using System;
using System.Linq;

/*----ASKED DiskSpace CLASS----*/
public class DiskSpace{
	/*----ASKED minDrives IMPLEMENTATION----*/
	/*----THE GENERAL IDEA IS TO IMPLEMENT A GREEDY ALGORITHM----*/
	public int minDrives(int[] used, int[] total){
		/*----PUT ALL USED DATA TOGETHER----*/
		int usedSum = used.Sum();
		/*----SORT TOTAL ARRAY TO USE FIRST THE LARGEST DRIVE----*/
		Array.Sort(total);
		int totalLength = total.Length;

		int i = totalLength - 1;
		int minD = 0;
		/*----GREEDILY CHOOSE THE OPTION THAT MINIMAZE THE TOTAL NUMBER OF HARD DRIVES NEDDED TO STORE THE DATA----*/
		while(i>=0 & usedSum>0){
			usedSum -= total[i];
			i--;
			minD++;
		}

		return minD;
	}

	public static void Main(){
		string menu = "0";
		do{
			/*----DISPLAY MAIN MENU----*/
			System.Console.WriteLine("Main menu:");
			System.Console.WriteLine("1. Test a known example.");
			System.Console.WriteLine("2. Create and test an example.");
			System.Console.WriteLine("3. Exit.\n");

			System.Console.Write("> ");
			menu = Console.ReadLine();

			switch(menu){
				case "1":
					Test.exampleTest();
					break;
				case "2":
					Test.customTest();
					break;
				case "3":
					System.Console.WriteLine("End.");
					break;
				default:
					System.Console.WriteLine("ERROR: type '1' to test a known example, '2' to create and test an example or '3' to exit.");
					break;
			}

			if(menu!="3"){
				System.Console.WriteLine("\nPress ENTER to continue...");
				Console.ReadLine();
				Console.Clear();
			}
		} while(menu!="3");
	}
}

/***************************************************/
/*----AUXILIAR CLASS TO TEST minDrives FUNCTION----*/
public class Test{
	/*----TEST minDrives WITH KNOWN EXAMPLES----*/
	public static void exampleTest(){
		int[] used = null;
		int[] total = null;
		int expectedResult = -1;
		DiskSpace dS = null;
		int result = -1;
		/*---ASK THE NUMBER OF THE EXAMPLE TO BE TESTED----*/
		System.Console.WriteLine("Enter the number of the example:");
		System.Console.Write("> ");
		string example = Console.ReadLine();

		switch(example){
			case "0":
				/*----CASE 0 DATA----*/
				used = new int[] {300,525,110};
				total = new int[] {350,600,115};
				expectedResult = 2 ;

				printExampleData(used,total,expectedResult);
				/*----HERE IS THE minDrives CALL---*/
				dS = new DiskSpace();
				result = dS.minDrives(used, total);

				verify(expectedResult, result);
				break;
			case "1":
				/*----CASE 1 DATA----*/
				used = new int[] {1,200,200,199,200,200};
				total = new int[] {1000,200,200,200,200,200};
				expectedResult = 1;

				printExampleData(used,total,expectedResult);
				/*----HERE IS THE minDrives CALL---*/
				dS = new DiskSpace();
				result = dS.minDrives(used, total);

				verify(expectedResult, result);
				break;
			case "2":
				/*----CASE 2 DATA----*/
				used = new int[] {750,800,850,900,950};
				total = new int[] {800,850,900,950,1000};
				expectedResult = 5;
				
				printExampleData(used,total,expectedResult);
				/*----HERE IS THE minDrives CALL---*/
				dS = new DiskSpace();
				result = dS.minDrives(used, total);

				verify(expectedResult, result);
				break;
			case "3":
				/*----CASE 3 DATA----*/
				used = new int[] {49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49,49};
				total = new int[] {50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,};
				expectedResult = 49;
				
				printExampleData(used,total,expectedResult);
				/*----HERE IS THE minDrives CALL---*/
				dS = new DiskSpace();
				result = dS.minDrives(used, total);

				verify(expectedResult, result);
				break;
			case "4":
				/*----CASE 3 DATA----*/
				used = new int[] {331,242,384,366,428,114,145,89,381,170,329,190,482,246,2,38,220,290,402,385};
				total = new int[] {992,509,997,946,976,873,771,565,693,714,755,878,897,789,969,727,765,521,961,906};
				expectedResult = 6;
				
				printExampleData(used,total,expectedResult);
				/*----HERE IS THE minDrives CALL---*/
				dS = new DiskSpace();
				result = dS.minDrives(used, total);
				
				verify(expectedResult, result);
				break;
			default:
				System.Console.WriteLine("ERROR: case example {0} does not exist.", example);
				break;
		}
	}

	/*----TEST minDrives WITH CUSTOM EXAMPLES----*/
	public static void customTest(){
		/*----ASK THE TOTAL NUMBER OF HARD DRIVES AND ASSIGN IT TO totalHardDrives VARIABLE----*/
		System.Console.WriteLine("Enter the total number of hard drives. It must be an integer between 1 and 50:");
		int totalHardDrives;
		bool isInteger = false;
		bool totalHardDrivesError = false;

		do{
			System.Console.Write("> ");
			isInteger = int.TryParse(Console.ReadLine(), out totalHardDrives);
			/*----VERIFY IF THE TOTAL NUMBER OF HARD DRIVES IS OK----*/
			totalHardDrivesError = !isInteger | totalHardDrives<1 | totalHardDrives>50;

			if(totalHardDrivesError){
				System.Console.Write("ERROR: the total number of hard drives must be an integer between 1 and 50. Press ENTER and try again...");
				Console.ReadLine();
			}
		} while (totalHardDrivesError);

		int[] totalArr = new int[totalHardDrives];
		/*----ASK THE TOTAL CAPACITY OF EACH DRIVE AND ASSIGN IT TO totalArr ARRAY----*/
		System.Console.WriteLine("Enter the total capacity of each drive. It must be an integer between 1 and 1000:");

		for(int i=0; i<totalHardDrives; i++){
			int totali = 1;
			bool totaliError = false;

			do{
				System.Console.Write("> drive {0}: ",i);
				isInteger = int.TryParse(Console.ReadLine(), out totali);
				/*----VERIFY IF THE TOTAL CAPACITY OF DRIVE i IS OK----*/
				totaliError = !isInteger | totali<1 | totali>1000;

				if(totaliError){
					System.Console.Write("ERROR: the total capacity of drive {0} must be an integer between 1 and 1000. Press ENTER and try again...", i);
					Console.ReadLine();
				}
			} while (totaliError);

			totalArr[i] = totali;
		}

		int[] usedArr = new int[totalHardDrives];
		/*----ASK THE AMOUNT OF DISK SPACE USED ON EACH DRIVE AND ASSIGN IT TO usedArr ARRAY----*/
		System.Console.WriteLine("Enter the amount of disk space used on each drive. It must be an integer between 1 and 1000 and less than or equal to its total capacity:");

		for(int i=0; i<totalHardDrives; i++){
			int usedi = 1;
			bool usediError = false;

			do {
				System.Console.Write("> drive {0}: ",i);
				isInteger = int.TryParse(Console.ReadLine(), out usedi);
				/*----VERIFY IF THE AMOUNT OF DISK SAPCE USED ON DRIVE i IS OK----*/
				usediError = !isInteger | usedi>totalArr[i] | usedi<1 | usedi>1000;
				if(usediError){
					System.Console.Write("ERROR: the amount of disk space used on drive {0} must be an integer between 1 and 1000, and less than or equal to {1}. Press ENTER and try again...", i, totalArr[i]);
					Console.ReadLine();
				}
			} while (usediError);

			usedArr[i] = usedi;
		}

		/*----ASK THE EXPECTED RESULT AND ASSIGN IT TO expectedResult VARIABLE----*/
		System.Console.WriteLine("Enter the expected result. It must be an integer between 1 and {0}:",totalHardDrives);
		int expectedResult = -1;
		bool expectedResultError = false;
		do{
			System.Console.Write("> ");
			isInteger = int.TryParse(Console.ReadLine(), out expectedResult);
			/*----VERIFY IF THE expectedResult IS OK----*/
			expectedResultError = !isInteger | expectedResult<1 | expectedResult>totalHardDrives;

			if (expectedResultError){
				System.Console.Write("ERROR: the expected result must be an integer between 1 and {0}. Press ENTER and try again...",totalHardDrives);
				Console.ReadLine();
			}
		} while (expectedResultError);
		
		printExampleData(usedArr,totalArr,expectedResult);
		/*----HERE IS THE minDrives CALL---*/
		DiskSpace ds = new DiskSpace();
		int result = ds.minDrives(usedArr, totalArr);

		verify(expectedResult,result);
    }

    /*----COMPARE THE EXPECTED RESULT WITH THE OBTAINED RESULT AND PRINT THE RESULT----*/
	public static void verify(int expectedResult, int result){
		System.Console.WriteLine("\nEXAMPLE RESULT:");

		if(expectedResult == result){
			System.Console.WriteLine("Case PASSED!");
			System.Console.WriteLine("result: {0}", result);
		} else{
			System.Console.WriteLine("Case FAILED!");
			System.Console.WriteLine("result: {0}", result);
		}
	}

	/*----PRINT AN EXAMPLE'S DATA----*/
	public static void printExampleData(int[] used, int[] total, int expectedResult){
		System.Console.WriteLine("EXAMPLE DATA:");

		System.Console.Write("used:  {");
		for(int i=0; i<used.Length-1; i++)
			System.Console.Write("{0},", used[i]);
		System.Console.Write("{0}", used[used.Length-1]);
		System.Console.WriteLine("}");

		System.Console.Write("total: {");
		for(int j=0; j<total.Length-1; j++)
			System.Console.Write("{0},", total[j]);
		System.Console.Write("{0}", total[total.Length-1]);
		System.Console.WriteLine("}");

		System.Console.WriteLine("expected result: {0}", expectedResult);	
	}
}