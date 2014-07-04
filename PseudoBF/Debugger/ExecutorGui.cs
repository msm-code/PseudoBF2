using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace PseudoBF.Debugger {
    class ExecutorGui : Form {
        private Button btnSingleStep;
        private ListBox lbStack;
        private ListBox lbCode;
        private TextBox tbOutput;
        private TextBox tbActiveChunk;
        private Button btnExecChunk;
        ExecutorEngine executor;

        public ExecutorGui(IntermediateCode code) {
            this.executor = new ExecutorEngine(code, new SimpleExternalProvider(this));
            this.InitializeComponent();
            this.UpdateGuiFromState();
        }

        public void UpdateGuiFromState() {
            lbCode.Items.Clear();
            lbStack.Items.Clear();

            var chunk = executor.CurrentChunk;
            tbActiveChunk.Text = chunk.Name;
            if (chunk is ExternalChunk) {
                lbCode.Items.Add("(external code)");
            } else if (chunk is CodeChunk) {
                lbCode.Items.AddRange((chunk as CodeChunk).Opcodes.ToArray());
                lbCode.Items.Add(".exit");
            }
            lbCode.SelectedIndex = executor.CurrentOpcode;

            lbStack.Items.AddRange(executor.Stack.Elems.Cast<object>().ToArray());
        }

        private void InitializeComponent() {
            this.btnSingleStep = new System.Windows.Forms.Button();
            this.lbStack = new System.Windows.Forms.ListBox();
            this.lbCode = new System.Windows.Forms.ListBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tbActiveChunk = new System.Windows.Forms.TextBox();
            this.btnExecChunk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSingleStep
            // 
            this.btnSingleStep.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSingleStep.Location = new System.Drawing.Point(12, 12);
            this.btnSingleStep.Name = "btnSingleStep";
            this.btnSingleStep.Size = new System.Drawing.Size(128, 22);
            this.btnSingleStep.TabIndex = 0;
            this.btnSingleStep.Text = "Single Step";
            this.btnSingleStep.UseVisualStyleBackColor = true;
            this.btnSingleStep.Click += new System.EventHandler(this.btnSingleStep_Click);
            // 
            // lbStack
            // 
            this.lbStack.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbStack.FormattingEnabled = true;
            this.lbStack.ItemHeight = 14;
            this.lbStack.Location = new System.Drawing.Point(12, 68);
            this.lbStack.Name = "lbStack";
            this.lbStack.Size = new System.Drawing.Size(128, 158);
            this.lbStack.TabIndex = 1;
            // 
            // lbCode
            // 
            this.lbCode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCode.FormattingEnabled = true;
            this.lbCode.ItemHeight = 14;
            this.lbCode.Location = new System.Drawing.Point(146, 68);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(238, 158);
            this.lbCode.TabIndex = 2;
            // 
            // tbOutput
            // 
            this.tbOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbOutput.Location = new System.Drawing.Point(12, 232);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(372, 22);
            this.tbOutput.TabIndex = 6;
            // 
            // tbActiveChunk
            // 
            this.tbActiveChunk.Enabled = false;
            this.tbActiveChunk.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbActiveChunk.Location = new System.Drawing.Point(146, 40);
            this.tbActiveChunk.Name = "tbActiveChunk";
            this.tbActiveChunk.Size = new System.Drawing.Size(238, 22);
            this.tbActiveChunk.TabIndex = 7;
            // 
            // btnExecChunk
            // 
            this.btnExecChunk.Font = new System.Drawing.Font("Consolas", 9F);
            this.btnExecChunk.Location = new System.Drawing.Point(12, 39);
            this.btnExecChunk.Name = "btnExecChunk";
            this.btnExecChunk.Size = new System.Drawing.Size(128, 22);
            this.btnExecChunk.TabIndex = 8;
            this.btnExecChunk.Text = "Exec Chunk";
            this.btnExecChunk.UseVisualStyleBackColor = true;
            this.btnExecChunk.Click += new System.EventHandler(this.btnExecChunk_Click);
            // 
            // ExecutorGui
            // 
            this.ClientSize = new System.Drawing.Size(396, 260);
            this.Controls.Add(this.btnExecChunk);
            this.Controls.Add(this.tbActiveChunk);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.lbCode);
            this.Controls.Add(this.lbStack);
            this.Controls.Add(this.btnSingleStep);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExecutorGui";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSingleStep_Click(object sender, System.EventArgs e) {
            executor.SingleStep();
            UpdateGuiFromState();
        }

        private void btnExecChunk_Click(object sender, System.EventArgs e) {
            var initChunk = executor.CurrentChunk;
            while (executor.CurrentChunk == initChunk && !executor.Finished) { 
                executor.SingleStep(); 
            }
            UpdateGuiFromState();
        }

        class SimpleExternalProvider : IExternalProvider {
            ExecutorGui gui;

            public SimpleExternalProvider(ExecutorGui gui) {
                this.gui = gui;
            }

            public int Execute(ExternalChunk chunk, List<int> parameters) {
                if (chunk.Name == "_echo") {
                    gui.tbOutput.Text += (char)parameters[0];
                    return 0;
                } else if (chunk.Name == "_sub") {
                    return parameters[1] - parameters[0];
                } else if (chunk.Name == "_add") {
                    return parameters[1] + parameters[0];
                } else if (chunk.Name == "_eq") {
                    return parameters[1] == parameters[0] ? 1 : 0;
                } else { throw new System.NotImplementedException("Unknown chunk"); }
            }
        }
    }
}
