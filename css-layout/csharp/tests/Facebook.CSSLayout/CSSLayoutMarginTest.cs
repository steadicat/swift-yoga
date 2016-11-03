/**
 * Copyright (c) 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

/**
 * @Generated by gentest/gentest.sh with the following input
 *
<div id="margin_start" style="width: 100px; height: 100px; flex-direction: row;">
  <div style="width: 10px; margin-start: 10px;"></div>
</div>

<div id="margin_top" style="width: 100px; height: 100px;">
  <div style="height: 10px; margin-top: 10px;"></div>
</div>

<div id="margin_end" style="width: 100px; height: 100px; flex-direction: row; justify-content: flex-end;">
  <div style="width: 10px; margin-end: 10px;"></div>
</div>

<div id="margin_bottom" style="width: 100px; height: 100px; justify-content: flex-end;">
  <div style="height: 10px; margin-bottom: 10px;"></div>
</div>

<div id="margin_and_flex_row" style="width: 100px; height: 100px; flex-direction: row;">
  <div style="margin-start: 10px; margin-end; 10px; flex-grow: 1;"></div>
</div>

<div id="margin_and_flex_column" style="width: 100px; height: 100px;">
  <div style="margin-top: 10px; margin-bottom; 10px; flex-grow: 1;"></div>
</div>

<div id="margin_and_stretch_row" style="width: 100px; height: 100px; flex-direction: row;">
  <div style="margin-top: 10px; margin-bottom; 10px; flex-grow: 1;"></div>
</div>

<div id="margin_and_stretch_column" style="width: 100px; height: 100px;">
  <div style="margin-start: 10px; margin-end; 10px; flex-grow: 1;"></div>
</div>

<div id="margin_with_sibling_row" style="width: 100px; height: 100px; flex-direction: row;">
  <div style="margin-end; 10px; flex-grow: 1;"></div>
  <div style="flex-grow: 1;"></div>
</div>

<div id="margin_with_sibling_column" style="width: 100px; height: 100px;">
  <div style="margin-bottom; 10px; flex-grow: 1;"></div>
  <div style="flex-grow: 1;"></div>
</div>
 *
 */

using System;
using NUnit.Framework;

namespace Facebook.CSSLayout
{
    [TestFixture]
    public class CSSLayoutMarginTest
    {
        [Test]
        public void Test_margin_start()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.SetMargin(CSSEdge.Start, 10);
            root_child0.StyleWidth = 10;
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(10, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(10, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(80, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(10, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_top()
        {
            CSSNode root = new CSSNode();
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.SetMargin(CSSEdge.Top, 10);
            root_child0.StyleHeight = 10;
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_end()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.JustifyContent = CSSJustify.FlexEnd;
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.SetMargin(CSSEdge.End, 10);
            root_child0.StyleWidth = 10;
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(80, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(10, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(10, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(10, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_bottom()
        {
            CSSNode root = new CSSNode();
            root.JustifyContent = CSSJustify.FlexEnd;
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.SetMargin(CSSEdge.Bottom, 10);
            root_child0.StyleHeight = 10;
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(80, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(80, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_and_flex_row()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.FlexGrow = 1;
            root_child0.SetMargin(CSSEdge.Start, 10);
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(10, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(90, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(90, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_and_flex_column()
        {
            CSSNode root = new CSSNode();
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.FlexGrow = 1;
            root_child0.SetMargin(CSSEdge.Top, 10);
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(90, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(90, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_and_stretch_row()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.FlexGrow = 1;
            root_child0.SetMargin(CSSEdge.Top, 10);
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(90, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(90, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_and_stretch_column()
        {
            CSSNode root = new CSSNode();
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.FlexGrow = 1;
            root_child0.SetMargin(CSSEdge.Start, 10);
            root.Insert(0, root_child0);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(10, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(90, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(90, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);
        }

        [Test]
        public void Test_margin_with_sibling_row()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.FlexGrow = 1;
            root.Insert(0, root_child0);

            CSSNode root_child1 = new CSSNode();
            root_child1.FlexGrow = 1;
            root.Insert(1, root_child1);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(50, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);

            Assert.AreEqual(50, root_child1.LayoutX);
            Assert.AreEqual(0, root_child1.LayoutY);
            Assert.AreEqual(50, root_child1.LayoutWidth);
            Assert.AreEqual(100, root_child1.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(50, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(50, root_child0.LayoutWidth);
            Assert.AreEqual(100, root_child0.LayoutHeight);

            Assert.AreEqual(0, root_child1.LayoutX);
            Assert.AreEqual(0, root_child1.LayoutY);
            Assert.AreEqual(50, root_child1.LayoutWidth);
            Assert.AreEqual(100, root_child1.LayoutHeight);
        }

        [Test]
        public void Test_margin_with_sibling_column()
        {
            CSSNode root = new CSSNode();
            root.StyleWidth = 100;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.FlexGrow = 1;
            root.Insert(0, root_child0);

            CSSNode root_child1 = new CSSNode();
            root_child1.FlexGrow = 1;
            root.Insert(1, root_child1);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(50, root_child0.LayoutHeight);

            Assert.AreEqual(0, root_child1.LayoutX);
            Assert.AreEqual(50, root_child1.LayoutY);
            Assert.AreEqual(100, root_child1.LayoutWidth);
            Assert.AreEqual(50, root_child1.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(100, root_child0.LayoutWidth);
            Assert.AreEqual(50, root_child0.LayoutHeight);

            Assert.AreEqual(0, root_child1.LayoutX);
            Assert.AreEqual(50, root_child1.LayoutY);
            Assert.AreEqual(100, root_child1.LayoutWidth);
            Assert.AreEqual(50, root_child1.LayoutHeight);
        }

    }
}
