using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace automata
{
    public partial class managexml : Form
    {
        private XmlDocument docXML = new XmlDocument();
        private String FileName = "";
        public managexml()
        {
            InitializeComponent();
        }

        private void managexml_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = ofd.FileName;
                docXML.Load(FileName);
            }
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            TreeNode nodeRoot;
            TreeNode nodeType;
            TreeNode nodeSymbols;
            TreeNode nodeSymbol;
            TreeNode nodeStateNumber;
            TreeNode nodeInitialState;
            TreeNode nodeFinalStates;
            TreeNode nodeTransitions;
            TreeNode nodeTransition;
            TreeNode node;
            nodeRoot = treeView1.Nodes.Add("automaton");
            nodeRoot.Tag = "automaton";
            XmlElement root = docXML.DocumentElement;
            String typeElement = root.SelectNodes("type")[0].InnerText.Trim();
            nodeType = nodeRoot.Nodes.Add("Τύπος");
            nodeType.Tag = "type";
            DropDownTreeNode ddnode = new DropDownTreeNode(typeElement);
            ddnode.ComboBox.Items.Add("NFA");
            ddnode.ComboBox.Items.Add("DFA");
            ddnode.ComboBox.Items.Add("PDA");
            ddnode.ComboBox.SelectedIndex = ddnode.ComboBox.Items.IndexOf(typeElement);
            ddnode.Tag = "value";
            nodeType.Nodes.Add(ddnode);
            nodeSymbols = nodeRoot.Nodes.Add("Σύμβολα");
            nodeSymbols.Tag = "symbols";
            XmlNodeList symbolList = root.SelectNodes("symbols")[0].SelectNodes("symbol");

            foreach (XmlNode item in symbolList) 
            {
                nodeSymbol = nodeSymbols.Nodes.Add(item.InnerText.Trim());
                nodeSymbol.Tag = "symbol";
                /*
                int initialState = 0;
                int finalState = 0;
                if (item.Attributes["initialState"] != null)
                {
                    initialState = int.Parse(item.Attributes["initialState"].Value);
                }
                if (item.Attributes["finalState"] != null)
                {
                    finalState = int.Parse(item.Attributes["finalState"].Value);
                }
                nodeSymbol.ImageIndex = initialState + 2 * finalState + 1;
                 */
            }
            nodeStateNumber = nodeRoot.Nodes.Add("Αριθμός καταστάσεων");
            nodeStateNumber.Tag = "stateNumber";
            String stateNumberElement = root.SelectNodes("stateNumber")[0].InnerText.Trim();
            node = nodeStateNumber.Nodes.Add(stateNumberElement);
            node.Tag = "value";

            nodeInitialState = nodeRoot.Nodes.Add("Αρχική κατάσταση");
            nodeInitialState.Tag = "initialState";
            String initialStateElement = root.SelectNodes("initialState")[0].InnerText.Trim();
            node = nodeInitialState.Nodes.Add(initialStateElement);
            node.Tag = "value";

            nodeFinalStates = nodeRoot.Nodes.Add("Τελικές καταστάσεις");
            nodeFinalStates.Tag = "finalStates";
            XmlNodeList finalStatesList = root.SelectNodes("finalStates")[0].SelectNodes("finalState");

            foreach (XmlNode item in finalStatesList)
            {
                node = nodeFinalStates.Nodes.Add(item.InnerText.Trim());
                node.Tag = "finalState";
            }
            
            nodeTransitions = nodeRoot.Nodes.Add("Μεταβάσεις");
            nodeTransitions.Tag = "transitions";
            XmlNodeList transitionsList = root.SelectNodes("transitions")[0].SelectNodes("transition");
            foreach (XmlNode item in transitionsList)
            {
                String stateFrom = item.Attributes["stateFrom"].Value;
                String stateTo = item.Attributes["stateFrom"].Value;
                String symbol = item.Attributes["symbol"].Value;
                nodeTransition = nodeTransitions.Nodes.Add("Μετάβαση " + stateFrom + " " + symbol + " " + stateTo);
                nodeTransition.Tag = "transition";
                node = nodeTransition.Nodes.Add("Αρχική κατάσταση");
                node.Tag = "attr, stateFrom";
                node = node.Nodes.Add(stateFrom);
                node = nodeTransition.Nodes.Add("Σύμβολο");
                node.Tag = "attr, symbol";
                node = node.Nodes.Add(symbol);
                node = nodeTransition.Nodes.Add("Τελική κατάσταση");
                node.Tag = "attr, stateTo";
                node = node.Nodes.Add(stateTo);
                if (typeElement == "PDA")
                {
                    String stackOut = item.Attributes["stackOut"].Value;
                    String stackIn = item.Attributes["stackIn"].Value;
                    node = nodeTransition.Nodes.Add("Εξαγωγή από στοίβα");
                    node.Tag = "attr, stackOut";
                    node = node.Nodes.Add(stackOut);
                    node = nodeTransition.Nodes.Add("Εισαγωγή σε στοίβα");
                    node.Tag = "attr, stackIn";
                    node = node.Nodes.Add(stackIn);
                    nodeTransition.Text += " " + stackOut + " " + stackIn;
                }
            }
            nodeRoot.Expand();
            nodeType.Expand();
            nodeSymbols.Expand();
            nodeTransitions.Expand();
            nodeStateNumber.Expand();
            nodeFinalStates.ExpandAll();
            nodeInitialState.Expand();
            treeView1.EndUpdate();
            treeView1.Refresh();
        }

        private void SaveNodes(TreeNodeCollection nodesCollection,
                                    XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                /*if (node.Text == "transition")
                    textWriter.WriteAttributeString("stateFrom", node.Text);
                textWriter.WriteAttributeString(
                    XmlNodeImageIndexAtt, node.ImageIndex.ToString());
                if (node.Tag != null)
                    textWriter.WriteAttributeString(XmlNodeTagAtt,
                                                node.Tag.ToString());
                // add other node properties to serialize here  
                 * */
                if (node.Nodes.Count > 0)
                {
                    if (node.Tag.ToString().StartsWith("attr,"))
                    {
                        String attr = node.Tag.ToString().Substring(5);
                        textWriter.WriteAttributeString(attr, node.Nodes[0].Text);
                    }
                    else
                    {
                        textWriter.WriteStartElement(node.Tag.ToString());
                        SaveNodes(node.Nodes, textWriter);
                        textWriter.WriteEndElement();
                    }
                }
                else
                {
                    if (node.Tag == null)
                        textWriter.WriteValue(node.Text);
                    else
                    {
                        textWriter.WriteStartElement(node.Tag.ToString());
                        textWriter.WriteValue(node.Text);
                        textWriter.WriteEndElement();
                    }
                }
                
            }         
        }

        private void saveTree(String filename)
        {
            XmlTextWriter textWriter = new XmlTextWriter(filename,
                                     System.Text.Encoding.UTF8);
            textWriter.Formatting = Formatting.Indented;
            textWriter.Indentation = 2;
            textWriter.WriteStartDocument();
            SaveNodes(treeView1.Nodes, textWriter);
            textWriter.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            saveTree(FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = sfd.FileName;
                saveTree(filename);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private TreeNode m_OldSelectNode;
        private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Show menu only if the right mouse button is clicked.
            if (e.Button == MouseButtons.Right)
            {

                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeView1.GetNodeAt(p);
                if (node != null)
                {

                    // Select the node the user has clicked.
                    // The node appears selected until the menu is displayed on the screen.
                    m_OldSelectNode = treeView1.SelectedNode;
                    treeView1.SelectedNode = node;

                    // Find the appropriate ContextMenu depending on the selected node.
                    String tag = Convert.ToString(node.Tag);
                    switch (tag)
                    {
                        case "symbols":
                        case "finalStates":
                        case "transitions":
                            menuParent.Tag = node;
                            menuParent.Show(treeView1, p);
                            break;
                        case "symbol":
                        case "finalState":
                        case "transition":
                            menuParent.Tag = node.Parent;
                            menuChild.Tag = node;
                            menuChild.Show(treeView1, p);
                            break;
                    }

                    // Highlight the selected node.
                    treeView1.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNode();
        }

        private void addNode()
        {
            TreeNode node = (menuParent.Tag as TreeNode);
            string tag = node.Tag.ToString();
            string newTag = "";
            AddForm addForm = null;
            switch (tag)
            {
                case "symbols":
                case "symbol":
                    newTag = "symbol";
                    addForm = new addXMLValue("symbol");
                    break;
                case "finalStates":
                case "finalState":
                    newTag = "finalState";
                    addForm = new addXMLValue("finalState");
                    break;
                case "transitions":
                case "transition":
                    newTag = "transition";
                    addForm = new addXMLValueTrans("Προσθήκη μετάβασης");
                    break;
            }
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                TreeNode newNode = addForm.getNode();
                newNode.Tag = newTag;
                node.Nodes.Add(newNode);
            }
        }

        private void addChild_Click(object sender, EventArgs e)
        {
            addNode();
        }

        private void deleteChild_Click(object sender, EventArgs e)
        {
            TreeNode node = (menuChild.Tag as TreeNode);
            node.Parent.Nodes.Remove(node);
        }
    }
}
