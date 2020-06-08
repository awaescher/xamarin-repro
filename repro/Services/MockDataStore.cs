using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repro.Models;

namespace repro.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		readonly List<Item> items;

		public MockDataStore()
		{
			items = new List<Item>()
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", LongText = Intro},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." , LongText = Lorem},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", LongText = Lorem },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." , LongText = Lorem},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." , LongText = Lorem},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", LongText = Lorem }
			};
		}

		public string Intro { get; }
			= "This cell contains a autosized editor (AutoSize=TextChanges) in combination with a long text in a TableView. " +
			"As soon as you start editing, you can add more text and scroll within the cell." +
			System.Environment.NewLine + System.Environment.NewLine +
			"Just add a few new lines - it'll work well. But the editor does not size with " +
			"the text. Instead, a scrollbar is shown. I'd expect the editor to behave like " +
			"the editor for Notes in Apple's Contacts app does." +
			System.Environment.NewLine + System.Environment.NewLine +
			"It's not that the cell would not be able to change the size individually. Just add a few lines " +
			"and switch to another page and back to this. The cell is sized perfectly.";

		public string Lorem { get; }
			= "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt " +
			"ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo.";

		public async Task<bool> AddItemAsync(Item item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}