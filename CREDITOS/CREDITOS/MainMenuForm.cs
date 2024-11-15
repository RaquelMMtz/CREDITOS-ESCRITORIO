using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CREDITOS
{
    public partial class MainMenuForm : Form
    {
        private Panel menuPanel;
        private Button resumenButton;
        private Button consultasButton;
        private Button solicitarCreditoButton;
        private Button pagarCreditoButton;
        private Button comprarProductosButton;
        private Button perfilButton;
        private PictureBox resumenIcon;
        private PictureBox consultasIcon;
        private PictureBox solicitarCreditoIcon;
        private PictureBox pagarCreditoIcon;
        private PictureBox comprarProductosIcon;
        private PictureBox perfilIcon;
        private Panel contentPanel;
        private Label welcomeLabel;
        private PictureBox welcomeImage;

        public MainMenuForm()
        {
            InitializeComponent();
            this.Text = "Menú Principal - Aplicación de Crédito Tienda Departamental";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

          
            this.Paint += (sender, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle,
                    Color.FromArgb(0, 51, 102), 
                    Color.FromArgb(102, 178, 255), 
                    90F);
                e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
            };

           
            menuPanel = new Panel
            {
                Size = new Size(250, this.ClientSize.Height),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(150, 0, 51, 102), 
                BorderStyle = BorderStyle.None,
                Padding = new Padding(10)
            };
            this.Controls.Add(menuPanel);

            int iconSpacing = 70; 

            
            string[] buttonNames = { "Resumen", "Consultas", "Aumentar Crédito", "Pagar Crédito", "Catalogo", "Perfil", "Cerrar Sesión" };
            string[] iconPaths = {
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\asdfgh.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen111.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\aume.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\pagarc.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\carr.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen6.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen7.png" 
    };
            EventHandler[] eventHandlers = {
        ResumenButton_Click,
        ConsultasButton_Click,
        SolicitarCreditoButton_Click,
        PagarCreditoButton_Click,
        ComprarProductosButton_Click,
        PerfilButton_Click,
        LogoutButton_Click
    };

            for (int i = 0; i < buttonNames.Length; i++)
            {
                
                if (!string.IsNullOrEmpty(iconPaths[i]))
                {
                    PictureBox icon = new PictureBox
                    {
                        Image = Image.FromFile(iconPaths[i]), 
                        Size = new Size(40, 40),
                        Location = new Point(15, 30 + i * iconSpacing),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    menuPanel.Controls.Add(icon);
                }

                // Agregar botón
                Button menuButton = new Button
                {
                    Text = buttonNames[i],
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Size = new Size(160, 50),
                    Location = new Point(70, 25 + i * iconSpacing),
                    BackColor = (buttonNames[i] == "Cerrar Sesión") ? Color.FromArgb(211, 47, 47) : Color.FromArgb(0, 102, 204), 
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 1, BorderColor = Color.White }
                };
                menuButton.Click += eventHandlers[i];
                menuPanel.Controls.Add(menuButton);
            }

            
            contentPanel = new Panel
            {
                Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height),
                Location = new Point(250, 0),
                BackColor = Color.FromArgb(255, 255, 255), 
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(contentPanel);

            welcomeLabel = new Label
            {
                Text = "¡Bienvenido a la Aplicación de Crédito!",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point((contentPanel.Width - 600) / 2, 50),
                Size = new Size(600, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(welcomeLabel);

            
            welcomeImage = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\cre.png"), // Cambiar por la ruta correcta de la imagen
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(200, 200),
                Location = new Point((contentPanel.Width - 200) / 2, 150)
            };
            contentPanel.Controls.Add(welcomeImage);
        }

        private void ResumenButton_Click(object sender, EventArgs e)
        {
            
            contentPanel.Controls.Clear();

            
            Label resumenTitle = new Label
            {
                Text = "Resumen de Crédito",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point((contentPanel.Width - 400) / 2, 20),
                Size = new Size(400, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(resumenTitle);

            
            Panel resumenPanel = new Panel
            {
                Size = new Size(700, 400),
                Location = new Point((contentPanel.Width - 700) / 2, 100),
                BackColor = Color.White, 
                BorderStyle = BorderStyle.FixedSingle
            };
            contentPanel.Controls.Add(resumenPanel);

           
            Label creditoDisponibleLabel = new Label
            {
                Text = "Crédito Total: $3000",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 20),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(creditoDisponibleLabel);

           
            Label totalGastadoLabel = new Label
            {
                Text = "Crédito Disponible: $1500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 70),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(totalGastadoLabel);

            
            Label pagosVencidosLabel = new Label
            {
                Text = "Crédito Utilizado: 1500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 120),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(pagosVencidosLabel);

          
            Label PV = new Label
            {
                Text = "Pagos Vencidos: 0",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 180),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(PV);

            
            Chart creditoChart = new Chart
            {
                Size = new Size(300, 200),
                Location = new Point(350, 20)
            };
            ChartArea chartArea = new ChartArea();
            creditoChart.ChartAreas.Add(chartArea);
            Series series = new Series
            {
                Name = "Credito",
                ChartType = SeriesChartType.Pie
            };
            series.Points.Add(new DataPoint(0, 1500) { LegendText = "Disponible", Color = Color.FromArgb(0, 102, 204) }); 
            series.Points.Add(new DataPoint(0, 1500) { LegendText = "Usado", Color = Color.FromArgb(102, 178, 255) }); 
            creditoChart.Series.Add(series);
            resumenPanel.Controls.Add(creditoChart);

            
            Label proximoPagoLabel = new Label
            {
                Text = "Próximo Pago: $500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 220),
                Size = new Size(400, 30)
            };
            resumenPanel.Controls.Add(proximoPagoLabel);

            
            Label fechaCorteLabel = new Label
            {
                Text = "Fecha de Corte: 30/11/2024",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 270),
                Size = new Size(400, 30)
            };
            resumenPanel.Controls.Add(fechaCorteLabel);

           
            Label fechaPagoLabel = new Label
            {
                Text = "Fecha de Pago: 05/12/2024",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 320),
                Size = new Size(400, 30)
            };
            resumenPanel.Controls.Add(fechaPagoLabel);
        }

        private void ConsultasButton_Click(object sender, EventArgs e)
        {
            
            contentPanel.Controls.Clear();

            
            Label consultasTitle = new Label
            {
                Text = "Consultas de Crédito",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), 
                Location = new Point((contentPanel.Width - 450) / 2, 20),
                Size = new Size(450, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(consultasTitle);

         
            Panel consultasPanel = new Panel
            {
                Size = new Size(750, 500),
                Location = new Point((contentPanel.Width - 750) / 2, 100),
                BackColor = Color.White, 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };
            contentPanel.Controls.Add(consultasPanel);

            
            Chart pagosChart = new Chart
            {
                Size = new Size(500, 150),
                Location = new Point(25, 20)
            };
            ChartArea pagosChartArea = new ChartArea();
            pagosChartArea.AxisY.Minimum = 0;
            pagosChartArea.AxisY.Maximum = 100;
            pagosChartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            pagosChartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            pagosChart.ChartAreas.Add(pagosChartArea);
            Series pagosSeries = new Series
            {
                Name = "Pagos",
                ChartType = SeriesChartType.Bar
            };
            pagosSeries.Points.Add(new DataPoint(0, 60) { AxisLabel = "Pagos Completados", Color = Color.FromArgb(0, 102, 204) }); 
            pagosSeries.Points.Add(new DataPoint(0, 40) { AxisLabel = "Pagos Pendientes", Color = Color.FromArgb(102, 178, 255) }); 
            pagosChart.Series.Add(pagosSeries);
            consultasPanel.Controls.Add(pagosChart);

            
            Panel historialComprasPanel = new Panel
            {
                Size = new Size(500, 150),
                Location = new Point(25, 180),
                BackColor = Color.FromArgb(245, 245, 245), 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };
            Label historialComprasLabel = new Label
            {
                Text = "Historial de Compras",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), 
                Location = new Point(10, 10),
                Size = new Size(250, 30)
            };
            historialComprasPanel.Controls.Add(historialComprasLabel);

            
            DataGridView historialComprasGrid = new DataGridView
            {
                Size = new Size(460, 80),
                Location = new Point(10, 50),
                ColumnCount = 3,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.White
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(0, 102, 204)
                },
                GridColor = Color.FromArgb(220, 220, 220) 
            };
            historialComprasGrid.Columns[0].Name = "Producto";
            historialComprasGrid.Columns[1].Name = "Fecha";
            historialComprasGrid.Columns[2].Name = "Monto";

            historialComprasGrid.Rows.Add("Televisor", "10/11/2024", "$2000");
            historialComprasGrid.Rows.Add("Lavadora", "15/11/2024", "$1500");
            historialComprasGrid.Rows.Add("Refrigerador", "20/11/2024", "$2500");

            
            Label totalGastadoLabel = new Label
            {
                Text = "Total Gastado: $6000",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 130),
                Size = new Size(300, 30)
            };

            historialComprasPanel.Controls.Add(historialComprasGrid);
            historialComprasPanel.Controls.Add(totalGastadoLabel);
            consultasPanel.Controls.Add(historialComprasPanel);

            
            Panel tarjetaPagos = new Panel
            {
                Size = new Size(150, 90),
                Location = new Point(25, 350),
                BackColor = Color.FromArgb(230, 230, 250), 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            Label pagosLabel = new Label
            {
                Text = "Pagos Realizados:\n- $500 (20/11/2024)\n- $1000 (25/11/2024)\nTotal Pagado: $1500",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                Size = new Size(130, 70)
            };
            tarjetaPagos.Controls.Add(pagosLabel);
            consultasPanel.Controls.Add(tarjetaPagos);

            Panel tarjetaPendientes = new Panel
            {
                Size = new Size(150, 90),
                Location = new Point(200, 350),
                BackColor = Color.FromArgb(230, 230, 250), 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            Label pendientesLabel = new Label
            {
                Text = "Créditos Pendientes:\n- Monto: $1000\nPróximo Vencimiento: 05/12/2024",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                Size = new Size(130, 70)
            };
            tarjetaPendientes.Controls.Add(pendientesLabel);
            consultasPanel.Controls.Add(tarjetaPendientes);

            Panel tarjetaComprasPendientes = new Panel
            {
                Size = new Size(150, 90),
                Location = new Point(375, 350),
                BackColor = Color.FromArgb(230, 230, 250), 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            Label comprasPendientesLabel = new Label
            {
                Text = "Compras Pendientes de Pago:\n- Lavadora: $1500\nTotal: $1500",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                Size = new Size(130, 100)
            };
            tarjetaComprasPendientes.Controls.Add(comprasPendientesLabel);
            consultasPanel.Controls.Add(tarjetaComprasPendientes);
        }



        private void SolicitarCreditoButton_Click(object sender, EventArgs e)
        {
            
            contentPanel.Controls.Clear();

           
            Label solicitudTitle = new Label
            {
                Text = "Solicitud de Aumento de Crédito",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point((contentPanel.Width - 500) / 2, 20),
                Size = new Size(600, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(solicitudTitle);

            
            Panel solicitudPanel = new Panel
            {
                Size = new Size(700, 400),
                Location = new Point((contentPanel.Width - 700) / 2, 100),
                BackColor = Color.White, 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };
            contentPanel.Controls.Add(solicitudPanel);

            
            Label montoLabel = new Label
            {
                Text = "Monto Solicitado:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 20),
                Size = new Size(200, 30)
            };
            solicitudPanel.Controls.Add(montoLabel);

            
            TextBox montoTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(220, 20),
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black
            };
            solicitudPanel.Controls.Add(montoTextBox);

            
            Label motivoLabel = new Label
            {
                Text = "Motivo:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black, 
                Location = new Point(20, 80),
                Size = new Size(200, 30)
            };
            solicitudPanel.Controls.Add(motivoLabel);

            
            TextBox motivoTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(220, 80),
                Size = new Size(400, 100),
                Multiline = true,
                BackColor = Color.FromArgb(240, 240, 240), 
                ForeColor = Color.Black
            };
            solicitudPanel.Controls.Add(motivoTextBox);

           
            PictureBox decorImage = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\asdfgh.png"), 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
                Location = new Point(20, 200) 
            };
            solicitudPanel.Controls.Add(decorImage);

            
            Button enviarButton = new Button
            {
                Text = "Enviar Solicitud",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point((solicitudPanel.Width - 200) / 2, 300),
                BackColor = Color.FromArgb(0, 102, 204), 
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            enviarButton.Click += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(montoTextBox.Text) || string.IsNullOrWhiteSpace(motivoTextBox.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de enviar la solicitud.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                    MessageBox.Show("Solicitud de aumento de crédito enviada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    montoTextBox.Text = string.Empty;
                    motivoTextBox.Text = string.Empty;
                }
            };
            solicitudPanel.Controls.Add(enviarButton);
        }


        private void PagarCreditoButton_Click(object sender, EventArgs e)
        {
          
            contentPanel.Controls.Clear();

          
            Label pagoTitle = new Label
            {
                Text = "Pago de Crédito",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), 
                Location = new Point((contentPanel.Width - 400) / 2, 20),
                Size = new Size(400, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(pagoTitle);

         
            Panel pagoPanel = new Panel
            {
                Size = new Size(700, 550),
                Location = new Point((contentPanel.Width - 700) / 2, 100),
                BackColor = Color.White, 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };
            contentPanel.Controls.Add(pagoPanel);

           
            Label tarjetaLabel = new Label
            {
                Text = "Número de Tarjeta:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 20),
                Size = new Size(220, 30)
            };
            pagoPanel.Controls.Add(tarjetaLabel);

           
            TextBox tarjetaTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(240, 20),
                Size = new Size(400, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black
            };
            pagoPanel.Controls.Add(tarjetaTextBox);

           
            Label expiracionLabel = new Label
            {
                Text = "Fecha de Expiración (MM/AA):",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 80),
                Size = new Size(300, 30)
            };
            pagoPanel.Controls.Add(expiracionLabel);

            
            TextBox expiracionTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(320, 80),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black
            };
            pagoPanel.Controls.Add(expiracionTextBox);

            
            Label cvvLabel = new Label
            {
                Text = "Código CVV:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 140),
                Size = new Size(200, 30)
            };
            pagoPanel.Controls.Add(cvvLabel);

            
            TextBox cvvTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(220, 140),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                UseSystemPasswordChar = true
            };
            pagoPanel.Controls.Add(cvvTextBox);

            
            Label montoMinimoLabel = new Label
            {
                Text = "Monto Mínimo a Pagar: $500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 200),
                Size = new Size(400, 30)
            };
            pagoPanel.Controls.Add(montoMinimoLabel);

           
            Label montoPagarLabel = new Label
            {
                Text = "Monto a Pagar:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 260),
                Size = new Size(200, 30)
            };
            pagoPanel.Controls.Add(montoPagarLabel);

            
            TextBox montoPagarTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(220, 260),
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black
            };
            pagoPanel.Controls.Add(montoPagarTextBox);

            
            CheckBox pagoTotalCheckBox = new CheckBox
            {
                Text = "Pagar Totalidad de la Deuda",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 320),
                Size = new Size(300, 30)
            };
            pagoTotalCheckBox.CheckedChanged += (s, args) =>
            {
                if (pagoTotalCheckBox.Checked)
                {
                    montoPagarTextBox.Text = "6000"; 
                    montoPagarTextBox.Enabled = false;
                }
                else
                {
                    montoPagarTextBox.Text = "";
                    montoPagarTextBox.Enabled = true;
                }
            };
            pagoPanel.Controls.Add(pagoTotalCheckBox);

            
            Button pagarButton = new Button
            {
                Text = "Pagar",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point((pagoPanel.Width - 200) / 2, 400),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            pagarButton.Click += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(tarjetaTextBox.Text) || string.IsNullOrWhiteSpace(montoPagarTextBox.Text) ||
                    string.IsNullOrWhiteSpace(expiracionTextBox.Text) || string.IsNullOrWhiteSpace(cvvTextBox.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de realizar el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (decimal.TryParse(montoPagarTextBox.Text, out decimal montoPagar) && montoPagar < 500)
                {
                    MessageBox.Show("El monto a pagar debe ser igual o mayor al monto mínimo de $500.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                    MessageBox.Show("Pago realizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    tarjetaTextBox.Text = string.Empty;
                    expiracionTextBox.Text = string.Empty;
                    cvvTextBox.Text = string.Empty;
                    montoPagarTextBox.Text = string.Empty;
                    pagoTotalCheckBox.Checked = false;
                }
            };
            pagoPanel.Controls.Add(pagarButton);
        }

        private void ComprarProductosButton_Click(object sender, EventArgs e)
        {
            
            contentPanel.Controls.Clear();

            
            Label catalogoTitle = new Label
            {
                Text = "Catálogo de Productos",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), 
                Location = new Point((contentPanel.Width - 450) / 2, 20),
                Size = new Size(450, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(catalogoTitle);

            
            Panel catalogoPanel = new Panel
            {
                Size = new Size(750, 500),
                Location = new Point((contentPanel.Width - 750) / 2, 100),
                BackColor = Color.White, 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };
            contentPanel.Controls.Add(catalogoPanel);

           
            FlowLayoutPanel productosPanel = new FlowLayoutPanel
            {
                Size = new Size(700, 300),
                Location = new Point(25, 20),
                AutoScroll = true,
                BackColor = Color.White
            };

           
            List<(string, string, string, string)> productos = new List<(string, string, string, string)>
    {
        ("Televisor", "Smart TV 50'' 4K", "$2000", "C:\\Users\\USER\\Downloads\\LG 55” 4K UHD Smart TV 2160p webOS, 55UQ7070ZUE - Walmart_com.jpeg"),
        ("Lavadora", "Lavadora automática 15kg", "$1500", "C:\\Users\\USER\\Downloads\\Whirlpool FFB7038WPL 859991597030.jpeg"),
        ("Refrigerador", "Refrigerador de doble puerta", "$2500", "C:\\Users\\USER\\Downloads\\descarga (1).jpeg")
    };

            foreach (var producto in productos)
            {
                Panel productoPanel = new Panel
                {
                    Size = new Size(200, 280),
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(245, 245, 245),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox productoImagen = new PictureBox
                {
                    Image = Image.FromFile(producto.Item4),
                    Size = new Size(180, 120),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                productoPanel.Controls.Add(productoImagen);

                Label productoNombre = new Label
                {
                    Text = producto.Item1,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(10, 140),
                    Size = new Size(180, 25)
                };
                productoPanel.Controls.Add(productoNombre);

                Label productoDescripcion = new Label
                {
                    Text = producto.Item2,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Location = new Point(10, 170),
                    Size = new Size(180, 40)
                };
                productoPanel.Controls.Add(productoDescripcion);

                Label productoPrecio = new Label
                {
                    Text = producto.Item3,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    Location = new Point(10, 220),
                    Size = new Size(180, 25)
                };
                productoPanel.Controls.Add(productoPrecio);

                Button agregarCarritoButton = new Button
                {
                    Text = "Agregar al Carrito",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Size = new Size(160, 30),
                    Location = new Point(20, 250),
                    BackColor = Color.FromArgb(0, 102, 204),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 }
                };
                agregarCarritoButton.Click += (s, args) =>
                {
                    MessageBox.Show($"{producto.Item1} ha sido añadido al carrito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                productoPanel.Controls.Add(agregarCarritoButton);

                productosPanel.Controls.Add(productoPanel);
            }

            catalogoPanel.Controls.Add(productosPanel);

           
            Button procederCompraButton = new Button
            {
                Text = "Proceder a la Compra",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(250, 50),
                Location = new Point((catalogoPanel.Width - 250) / 2, 400),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            procederCompraButton.Click += (s, args) =>
            {
                MessageBox.Show("Los productos seleccionados han sido añadidos a su tarjeta de crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            catalogoPanel.Controls.Add(procederCompraButton);
        }


        private void PerfilButton_Click(object sender, EventArgs e)
        {
            
            contentPanel.Controls.Clear();

            
            Label perfilTitle = new Label
            {
                Text = "Perfil de Usuario",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), 
                Location = new Point((contentPanel.Width - 450) / 2, 20),
                Size = new Size(450, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(perfilTitle);

            
            Panel perfilPanel = new Panel
            {
                Size = new Size(750, 550),
                Location = new Point((contentPanel.Width - 750) / 2, 100),
                BackColor = Color.White, 
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };
            contentPanel.Controls.Add(perfilPanel);

           
            PictureBox perfilImagen = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\usuario.png"), 
                Size = new Size(100, 100),
                Location = new Point(25, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };
            perfilPanel.Controls.Add(perfilImagen);

            
            Button actualizarFotoButton = new Button
            {
                Text = "Actualizar Foto",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(120, 30),
                Location = new Point(140, 50),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            actualizarFotoButton.Click += (s, args) =>
            {
                MessageBox.Show("Funcionalidad para actualizar la foto de perfil.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            perfilPanel.Controls.Add(actualizarFotoButton);

            
            Label nombreUsuarioLabel = new Label
            {
                Text = "Nombre de Usuario:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 150),
                Size = new Size(225, 30)
            };
            perfilPanel.Controls.Add(nombreUsuarioLabel);

            
            TextBox nombreUsuarioTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(260, 150),
                Size = new Size(400, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                ReadOnly = true
            };
            perfilPanel.Controls.Add(nombreUsuarioTextBox);

            
            Label correoLabel = new Label
            {
                Text = "Correo Electrónico:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 200),
                Size = new Size(220, 30)
            };
            perfilPanel.Controls.Add(correoLabel);

         
            TextBox correoTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(240, 200),
                Size = new Size(400, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                ReadOnly = true
            };
            perfilPanel.Controls.Add(correoTextBox);

           
            Panel tarjetaCreditosUtilizados = new Panel
            {
                Size = new Size(220, 100),
                Location = new Point(20, 260),
                BackColor = Color.FromArgb(230, 230, 250), 
                BorderStyle = BorderStyle.FixedSingle
            };
            Label creditosUtilizadosLabel = new Label
            {
                Text = "Créditos Utilizados\nTotal: $4500",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                Size = new Size(200, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            tarjetaCreditosUtilizados.Controls.Add(creditosUtilizadosLabel);
            perfilPanel.Controls.Add(tarjetaCreditosUtilizados);

            
            Panel tarjetaCreditosPendientes = new Panel
            {
                Size = new Size(220, 100),
                Location = new Point(260, 260),
                BackColor = Color.FromArgb(230, 230, 250), 
                BorderStyle = BorderStyle.FixedSingle
            };
            Label creditosPendientesLabel = new Label
            {
                Text = "Créditos Pendientes\nTotal: $2000",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                Size = new Size(200, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            tarjetaCreditosPendientes.Controls.Add(creditosPendientesLabel);
            perfilPanel.Controls.Add(tarjetaCreditosPendientes);

            
            Label historialLabel = new Label
            {
                Text = "Historial de Actividades",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), 
                Location = new Point(20, 380),
                Size = new Size(300, 30)
            };
            perfilPanel.Controls.Add(historialLabel);

            
            DataGridView historialGrid = new DataGridView
            {
                Size = new Size(700, 120),
                Location = new Point(20, 420),
                ColumnCount = 3,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.White
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(0, 102, 204)
                },
                GridColor = Color.FromArgb(220, 220, 220) 
            };
            historialGrid.Columns[0].Name = "Fecha";
            historialGrid.Columns[1].Name = "Actividad";
            historialGrid.Columns[2].Name = "Monto";

            historialGrid.Rows.Add("01/12/2024", "Pago Realizado", "$500");
            historialGrid.Rows.Add("20/11/2024", "Compra - Televisor", "$2000");
            historialGrid.Rows.Add("15/11/2024", "Compra - Lavadora", "$1500");

            perfilPanel.Controls.Add(historialGrid);
        }


        private void LogoutButton_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Cerrando sesión...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }
        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
