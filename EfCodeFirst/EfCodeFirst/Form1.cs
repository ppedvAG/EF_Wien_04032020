﻿using EfCodeFirst.Data;
using EfCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EfContext context = new EfContext();

        private void button1_Click(object sender, EventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Steine" };
            var abt2 = new Abteilung() { Bezeichnung = "Holz" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred #{i:000}",
                    GebDatum = DateTime.Now.AddDays(i * 348),
                    Job = "Macht dinge"
                };

                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);
                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                context.Mitarbeiter.Add(m);
            }

            context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Mitarbeiter.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
