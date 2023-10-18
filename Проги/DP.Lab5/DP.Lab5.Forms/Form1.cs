using DP.Lab5.Service.Encoders;

namespace DP.Lab5.Forms
{
    public partial class Form1 : Form
    {
        private RotatingGrilleCipherEncoder _encoder = new RotatingGrilleCipherEncoder(
            new Service.Repository.SquareGrilleRepository(new List<List<char>>()
            {
                new List<char>() {' ', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', 'X', ' '},
                new List<char>() {'X', ' ', ' ', ' ', 'X', ' '},
                new List<char>() {' ', 'X', ' ', ' ', ' ', ' '}
            }));

        private int matrixVariationNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvGrille.Visible = false;
            btnNext.Visible = false;
            btnPrev.Visible = false;

            tbEncodedFromAlgorithm.ReadOnly = true;
            tbDecodedFromAlgorithm.ReadOnly = true;
            tbNormalized.ReadOnly = true;
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            var msg = tbInitMessage.Text;
            try
            {
                var encoded = _encoder.Encode(msg);
                tbNormalized.Text = _encoder.NormalizedMessage;
                tbEncodedFromAlgorithm.Text = encoded;
                matrixVariationNum = 0;
                LoadFilledMatrixVariation(matrixVariationNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadFilledMatrixVariation(int num)
        {
            dgvGrille.Visible = true;
            btnNext.Visible = true;
            btnPrev.Visible = true;

            dgvGrille.Rows.Clear();
            dgvGrille.Columns.Clear();

            var filled = _encoder.FilledMatrixVariations;

            for (int i = 0; i < filled[num][0].Count; i++)
            {
                dgvGrille.Columns.Add($"i", "");
            }

            for (int i = 0; i < filled[num].Count; i++)
            {
                dgvGrille.Rows.Add();
                for (int j = 0; j < filled[num][i].Count; j++)
                {
                    dgvGrille[j, i].Value = filled[num][i][j];
                }
            }

            dgvGrille.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvGrille.AllowUserToAddRows = false;
            dgvGrille.ReadOnly = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((matrixVariationNum + 1) < _encoder.FilledMatrixVariations.Count)
            {
                ++matrixVariationNum;
                LoadFilledMatrixVariation(matrixVariationNum);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if ((matrixVariationNum - 1) >= 0)
            {
                --matrixVariationNum;
                LoadFilledMatrixVariation(matrixVariationNum);
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            var encodedFromUser = tbEncoded.Text;
            try
            {
                var decoded = _encoder.Decode(encodedFromUser);
                tbDecodedFromAlgorithm.Text = decoded;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}