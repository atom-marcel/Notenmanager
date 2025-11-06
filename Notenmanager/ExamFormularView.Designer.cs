using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Notenmanager
{
    partial class ExamFormularView : Window
    {
        private Label title;
        private Label date;
        private TextField percent;
        private ComboBox subject;
        private ComboBox learningField;
        private Dictionary<string, Label> labels;
        private Button submit;
        private DateField dateField;

        private string[] fieldIDs =
        {
            "percent",
            "subject",
            "learningField",
        };

        private string[] labelText =
        {
            "Prozentpunkte:",
            "Thema:",
            "Lernfeld:"
        };
        private void InitializeComponent()
        {
            int countFields = fieldIDs.Length;
            int offset = (countFields / 2) * -1 - 2;

            title = new Label("Klausur hinzufügen");
            title.ColorScheme = Program.GLOBAL_CS_TITLE;
            title.X = Pos.Center();
            title.Y = Pos.Center() + offset;
            this.Add(title);
            offset += 2;

            labels = new Dictionary<string, Label>();

            for (int i = 0; i < countFields; i++)
            {
                Label l = new Label(labelText[i]);
                labels.Add(fieldIDs[i], l);
                l.X = Pos.Center() - labelText[i].Length - 1;
                l.Y = Pos.Center() + offset;

                this.Add(l);

                offset += 2;
            }

            percent = new TextField();
            percent.X = labels["percent"].X + labels["percent"].Text.Length + 1;
            percent.Y = labels["percent"].Y;
            percent.Width = 20;
            this.Add(percent);

            subject = new ComboBox(this.subjects);
            subject.X = labels["subject"].X + labels["subject"].Text.Length + 1;
            subject.Y = labels["subject"].Y;
            subject.Width = 20;
            subject.Height = 5;
            this.Add(subject);

            learningField = new ComboBox(this.learningFields);
            learningField.X = labels["learningField"].X + labels["learningField"].Text.Length + 1;
            learningField.Y = labels["learningField"].Y;
            learningField.Width = 20;
            learningField.Height = 5;
            this.Add(learningField);

            date = new Label("Datum:");
            date.X = Pos.Center() - date.Text.Length - 1;
            date.Y = Pos.Center() + offset;
            this.Add(date);

            dateField = new DateField();
            dateField.TextAlignment = TextAlignment.Left;
            dateField.X = Pos.Center() + 1;
            dateField.Y = Pos.Center() + offset;
            dateField.Date = DateTime.Now;
            offset += 2;
            this.Add(dateField);

            submit = new Button("Speichern");
            submit.X = Pos.Center();
            submit.Y = Pos.Center() + offset;

            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Modal = false;
            this.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.Border.Effect3D = false;
            this.Border.DrawMarginFrame = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.ColorScheme = Program.GLOBAL_CS;
            this.Title = "Crtl-Q drücken um zum Hauptmenü zu gelangen";

            this.Add(submit);
        }
    }
}
