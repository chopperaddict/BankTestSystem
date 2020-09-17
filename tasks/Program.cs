using System;
using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;

// This ia  working demo of M$ version of an example of Tasks implementation
// It aint simple ot understand, but I have documented it thoroughly
// so I can come back to it later ?
// It has a stopwatch implemented, amd takes around FIFTEEN SECONDS to complete,
// based on  quite a few people waiting for it
namespace tasks
{
	class Program
	{
		// Even our main is marked up as (async)  cos we call await in it, so it has to be...
		static async Task Main (string[] args) {
			// get a stopwatch and start it
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

			sw.Start();		// start the stopWatch before we strt our State Machine
			// Call all of the threads needed to  make breakfast in rough order, it dpesn't really matter
			var CoffeeTask = MakeCoffee ( 4 ); ;
			var eggsTask = FryEggsAsync ( 4 );
			var baconTask = FryBaconAsync ( 8 );
			var toastTask = MakeToastWithButterAndJamAsync ( 12 );

			//create a list of "Tasks"  that we need to have completed to achieve 'BreakFast'
			var breakfastTasks = new List<Task> { CoffeeTask, eggsTask, baconTask, toastTask };
			while ( breakfastTasks.Count > 0 )
			{
				Task finishedTask = await Task.WhenAny ( breakfastTasks );
				//START OF A STATE MACHINE BASICALLY	
				// here we check each thread we have had spawned to see if it has completed
				if ( finishedTask == eggsTask )
				{
					Console.WriteLine ( "----------------------------------------------------------------------------------" );
					Console.WriteLine ( $"{sw.Elapsed} ms - Eggs are ready" );
					Console.WriteLine ( "----------------------------------------------------------------------------------" );
				}
				else if ( finishedTask == baconTask )
				{
					Console.WriteLine ( "----------------------------------------------------------------------------------" );
					Console.WriteLine ( $"{sw.Elapsed} ms - Bacon is nice and crispy and ready to go" );
					Console.WriteLine ( "----------------------------------------------------------------------------------" );
				}
				else if ( finishedTask == toastTask )
				{
					Console.WriteLine ( "----------------------------------------------------------------------------------" );
					Console.WriteLine ( $"{sw.Elapsed} ms - toast is buttered and 'Jammed' and ready to eat" );
					Console.WriteLine ( "----------------------------------------------------------------------------------" );
				}
				breakfastTasks.Remove ( finishedTask );
			}
			//END OF STATE MACHINE
			//Eggs seem to get finished FIRST by quite  a good margin
			// it is another 5 seconds before the Bacon is done
			// & another 5 seocnds for the Toast to be completed
			// & then we just have to pour the OJ to be finjshed
			// & Breakfast is served... 15 + seconds !!

			Juice oj = PourOJ ( );
			Console.WriteLine ( "----------------------------------------------------------------------------------" );
			Console.WriteLine ( $"{sw.Elapsed} ms - oj has been poured & is now ready" );
			Console.WriteLine ( $"{sw.Elapsed} ms - YeeeHaaaaa - Breakfast is ready!" );
			Console.WriteLine ( "----------------------------------------------------------------------------------" );
			Console.ReadLine();

			// Start of the support task functions
			static async Task<Toast> MakeToastWithButterAndJamAsync (int number)
			{
				var toast = await ToastBreadAsync ( number );
				// wait for each process to complete
				await ApplyButter ( number );
				await ApplyJam ( number);
				return toast;
			}

			// this does not take any time, so not async
			static Juice PourOJ ( )
			{
				Console.WriteLine ( "Pouring orange juice" );
				return new Juice ( );
			}

			// This does take time, hence async
			static async Task <Toast>ApplyButter(int slices) {
				Console.WriteLine ( "Putting butter on the toast" );
				await Task.Delay ( 300 * slices );
				return new Toast();
			}

			// This does take time, hence async
			static async Task<Toast> ApplyJam (int slices) {
				Console.WriteLine("Putting jam on the toast");
				await Task.Delay ( 300  * slices);
				return new Toast();
			}

			// This does take time, hence async
			static async Task<Toast> ToastBreadAsync (int slices)
			{
					Console.WriteLine ( "Can only handle ONE slice at a  time in the toaster" );
			for ( int slice = 0; slice < slices; slice++ )
				{
					Console.WriteLine ( "Putting a slice of bread in the toaster" );
					await Task.Delay ( 700 );
					Console.WriteLine ( $"Remove slice {slice + 1} of toast from toaster" );
				}
				Console.WriteLine ( $"All {slices} slices of toast are nicely browned & ready for Butter & Jam" );
				return new Toast ( );
			}

			// This does take time, hence async
			static async Task<Bacon> FryBaconAsync (int slices)
			{
				Console.WriteLine ( $"putting {slices} slices of bacon in the pan" );
				Console.WriteLine ( "cooking first side of bacon..." );
				await Task.Delay ( 1500 );
				for (int slice = 0; slice < slices; slice++) {
					Console.WriteLine ( $"flipping {slices + 1} slices of bacon over to cook the other side" );
					await Task.Delay ( 1000 );
				}
				Console.WriteLine ( "Bacon Cooked - Putting bacon on the  plates" );
				await Task.Delay ( 1000 );
				return new Bacon ( );
			}

			// This does take time, hence async
			static async Task<Egg> FryEggsAsync (int howMany)
			{
				Console.WriteLine ( "Warming the egg pan..." );
				await Task.Delay ( 3000 );
				Console.WriteLine ( $"cracking {howMany} eggs" );
				Console.WriteLine ( "cooking all the eggs at one time..." );
				await Task.Delay ( 500 * howMany );
				Console.WriteLine ( $"All done nicely - Putting {howMany} eggs on plate" );
				return new Egg ( );
			}

			// This does take time, hence async
			static async Task<Coffee> MakeCoffee (int howMany)
			{
				Console.WriteLine ( "Boiling Water for coffee" );
				await Task.Delay ( 750 * howMany );
				Console.WriteLine ( $"Pouring {howMany} cups of boiling hot coffee" );
				await Task.Delay ( 750 * howMany );
				Console.WriteLine ( $"{howMany} Coffees all finished ");
				return new Coffee ( );
			}
		}

	
	}   // End class Program
}



