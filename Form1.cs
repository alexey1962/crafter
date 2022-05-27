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
        private static itemRecipe[] candleRecipe = {
            new itemRecipe { cell = 1, image = "carrot" },
            new itemRecipe { cell = 2, image = "candle" }
        };
        private static itemRecipe[] brickRecipe = {
            new itemRecipe { cell = 5, image = "book" },
            new itemRecipe { cell = 7, image = "lead" }
        };
        private CrafterConfig[] crafterConfigs =
        {
            new CrafterConfig {title = "candle", recipe = candleRecipe },
            new CrafterConfig {title = "brick", recipe = brickRecipe },
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
            result.BackgroundImage = null;
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
        public int cell;
        public string image;
    }
}
