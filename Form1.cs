using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crafter
{
    
    public partial class Form1 : Form
    {
        private static itemRecipe[] diamond_swordRecipe = {
            new itemRecipe { cell = "2", image = "stick" },
            new itemRecipe { cell = "5", image = "diamond" },
            new itemRecipe { cell = "8", image = "diamond" },
            new itemRecipe { cell = "result", image = "stick"}
        };
        private static itemRecipe[] diamond_pickaxeRecipe = {
            new itemRecipe { cell = "2", image = "stick" },
            new itemRecipe { cell = "5", image = "stick" },
            new itemRecipe { cell = "7", image = "diamond" },
            new itemRecipe { cell = "8", image = "diamond" },
            new itemRecipe { cell = "9", image = "diamond" },
            new itemRecipe {cell = "result", image = "stick"}
        };
        private CrafterConfig[] crafterConfigs =
        {
            new CrafterConfig {title = "diamond_sword", recipe = diamond_swordRecipe },
            new CrafterConfig {title = "diamond_pickaxe", recipe = diamond_pickaxeRecipe },
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void createItem(string name)
        {
            Button cellButton = new Button()
            {
                Height = 32,
                Width = 32,
                BackgroundImage = Image.FromFile("C:/projects/crafter/crafter/temp/item/" + name + ".png"),
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            cellButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                clearCraftingGrid();
                itemRecipe[] recipe = crafterConfigs.Where(item => item.title == name).First().recipe;
                updateCraftingGrid(recipe);
            });
            itemsWrapper.Controls.Add(cellButton);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            foreach (CrafterConfig item in crafterConfigs)
            {
                createItem(item.title);
            }
            
        }

        private void clearCraftingGrid()
        {
            for (int i = 1; i < 10; i++)
            {
                crafter.Controls["cell" + i].BackgroundImage = null;
            }
            cellresult.BackgroundImage = null;
        }

        private void updateCraftingGrid(itemRecipe[] config)
        {
           foreach (var item in config)
            {
                crafter.Controls["cell"+item.cell].BackgroundImage = Image.FromFile("C:/projects/crafter/crafter/temp/item/" + item.image + ".png");
            }
        }
    }
    public struct CrafterConfig
    {
        public string title;
        public itemRecipe[] recipe;
    }

    public struct itemRecipe {
        public string cell;
        public string image;
    }
}
