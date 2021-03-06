﻿#region (c) 2006 Matt Valerio
// DropDownTreeView Control
//
// 6.21.06 Matt Valerio
// (matt.valerio@gmail.com)
//
// Filename: DropDownTreeView.cs
//
// Description: Provides a DropDownTreeView control that extends the TreeView control by allowing a
// ComboBox to be displayed at specific TreeNodes to select the text of the node.
//
// ============================================================================
// This software is free software; you can modify and/or redistribute it, provided
// that the author is credited with the work.
//
// This library is distributed in the hope that it will be useful, but WITHOUT ANY
// WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
// PARTICULAR PURPOSE.
// ============================================================================
//
// Revisions:
//   1  6.21.06 MDV  Initial CodeProject article
//   2  7.21.06 MDV  Fixed BringToFront() suggestion in the comment by OrlandoCurioso
//                   Cleaned up the the node type determination as suggested in the comment by mpasqual
//                   Removed OnClick
//                   Overrode the OnMouseWheel function and called HideComboBox()
//                   Added handler for the DropDownChanged event of the ComboBox -- this alleviates many of the problems
//   3  7.24.06 MDV  Changed ComboBox dropdown to happen on click instead of label edit.
#endregion


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;


namespace automata
{
    /// <summary>
    /// Provides the usual TreeView control with the ability to edit the labels of the nodes
    /// by using a drop-down ComboBox.
    /// </summary>
    public class DropDownTreeView : TreeView
    {
        public const int NOIMAGE = -1;
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DropDownTreeView"/> class.
        /// </summary>
        public DropDownTreeView()
            : base()
        {
            base.LineColor = SystemColors.GrayText;
            base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }
        #endregion


        // We'll use this variable to keep track of the current node that is being edited.
        // This is set to something (non-null) only if the node's ComboBox is being displayed.
        private DropDownTreeNode m_CurrentNode = null;


        /// <summary>
        /// Occurs when the <see cref="E:System.Windows.Forms.TreeView.NodeMouseClick"></see> event is fired
        /// -- that is, when a node in the tree view is clicked.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data.</param>
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            // Are we dealing with a dropdown node?
            if (e.Node is DropDownTreeNode)
            {
                this.m_CurrentNode = (DropDownTreeNode)e.Node;

                // Need to add the node's ComboBox to the TreeView's list of controls for it to work
                this.Controls.Add(this.m_CurrentNode.ComboBox);

                // Set the bounds of the ComboBox, with a little adjustment to make it look right
                this.m_CurrentNode.ComboBox.SetBounds(
                    this.m_CurrentNode.Bounds.X - 1,
                    this.m_CurrentNode.Bounds.Y - 2,
                    this.m_CurrentNode.Bounds.Width + 25,
                    this.m_CurrentNode.Bounds.Height);

                // Listen to the SelectedValueChanged event of the node's ComboBox
                this.m_CurrentNode.ComboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);
                this.m_CurrentNode.ComboBox.DropDownClosed += new EventHandler(ComboBox_DropDownClosed);

                // Now show the ComboBox
                this.m_CurrentNode.ComboBox.Show();
                this.m_CurrentNode.ComboBox.DroppedDown = true;
            }
            base.OnNodeMouseClick(e);
        }


        /// <summary>
        /// Handles the SelectedValueChanged event of the ComboBox control.
        /// Hides the ComboBox if an item has been selected in it.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            HideComboBox();
        }


        /// <summary>
        /// Handles the DropDownClosed event of the ComboBox control.
        /// Hides the ComboBox if the user clicks anywhere else on the TreeView or adjusts the scrollbars, or scrolls the mouse wheel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            HideComboBox();
        }


        /// <summary>
        /// Handles the <see cref="E:System.Windows.Forms.Control.MouseWheel"></see> event.
        /// Hides the ComboBox if the user scrolls the mouse wheel.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            HideComboBox();
            base.OnMouseWheel(e);
        }


        /// <summary>
        /// Method to hide the currently-selected node's ComboBox
        /// </summary>
        private void HideComboBox()
        {
            if (this.m_CurrentNode != null)
            {
                // Unregister the event listener
                this.m_CurrentNode.ComboBox.SelectedValueChanged -= ComboBox_SelectedValueChanged;
                this.m_CurrentNode.ComboBox.DropDownClosed -= ComboBox_DropDownClosed;

                // Copy the selected text from the ComboBox to the TreeNode
                this.m_CurrentNode.Text = this.m_CurrentNode.ComboBox.Text;

                // Hide the ComboBox
                this.m_CurrentNode.ComboBox.Hide();
                this.m_CurrentNode.ComboBox.DroppedDown = false;

                // Remove the control from the TreeView's list of currently-displayed controls
                this.Controls.Remove(this.m_CurrentNode.ComboBox);

                // And return to the default state (no ComboBox displayed)
                this.m_CurrentNode = null;
            }

        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            const int SPACE_IL = 3;  // space between Image and Label

            // we only do additional drawing
            e.DrawDefault = true;

            base.OnDrawNode(e);

            if (base.ShowLines && base.ImageList != null && e.Node.ImageIndex == NOIMAGE
                // exclude root nodes, if root lines are disabled
                //&& (base.ShowRootLines || e.Node.Level > 0))
                )
            {
                // Using lines & images, but this node has none: fill up missing treelines

                // Image size
                int imgW = base.ImageList.ImageSize.Width;
                int imgH = base.ImageList.ImageSize.Height;

                // Image center
                int xPos = e.Node.Bounds.Left - SPACE_IL - imgW / 2;
                int yPos = (e.Node.Bounds.Top + e.Node.Bounds.Bottom) / 2;

                // Image rect
                Rectangle imgRect = new Rectangle(xPos, yPos, 0, 0);
                imgRect.Inflate(imgW / 2, imgH / 2);

                using (Pen p = new Pen(base.LineColor, 1))
                {
                    p.DashStyle = DashStyle.Dot;

                    // account uneven Indent for both lines
                    p.DashOffset = base.Indent % 2;

                    // Horizontal treeline across width of image
                    // account uneven half of delta ItemHeight & ImageHeight
                    int yHor = yPos + ((base.ItemHeight - imgRect.Height) / 2) % 2;

                    //if (base.ShowRootLines || e.Node.Level > 0)
                    //{
                    //    e.Graphics.DrawLine(p, imgRect.Left, yHor, imgRect.Right, yHor);
                    //}
                    //else
                    //{
                    //    // for root nodes, if root lines are disabled, start at center
                    //    e.Graphics.DrawLine(p, xPos - (int)p.DashOffset, yHor, imgRect.Right, yHor);
                    //}

                    e.Graphics.DrawLine(p,
                        (base.ShowRootLines || e.Node.Level > 0) ? imgRect.Left : xPos - (int)p.DashOffset,
                        yHor, imgRect.Right, yHor);


                    if (!base.CheckBoxes && e.Node.IsExpanded)
                    {
                        // Vertical treeline , offspring from NodeImage center to e.Node.Bounds.Bottom
                        // yStartPos: account uneven Indent and uneven half of delta ItemHeight & ImageHeight
                        int yVer = yHor + (int)p.DashOffset;
                        e.Graphics.DrawLine(p, xPos, yVer, xPos, e.Node.Bounds.Bottom);
                    }
                }
            }
        }

        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            base.OnAfterCollapse(e);

            if (!base.CheckBoxes && base.ImageList != null && e.Node.ImageIndex == NOIMAGE)
            {
                // DrawNode event not raised: redraw node with collapsed treeline
                base.Invalidate(e.Node.Bounds);
            }
        }
    }
}
