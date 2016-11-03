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
<div id="wrap_column" style="height: 100px; flex-wrap: wrap">
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
</div>

<div id="wrap_row" style="width: 100px; flex-direction: row; flex-wrap: wrap">
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
</div>

<div id="wrap_row_align_items_flex_end" style="width: 100px; flex-direction: row; flex-wrap: wrap; align-items: flex-end;">
  <div style="height: 10px; width: 30px;"></div>
  <div style="height: 20px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
</div>

<div id="wrap_row_align_items_center" style="width: 100px; flex-direction: row; flex-wrap: wrap; align-items: center;">
  <div style="height: 10px; width: 30px;"></div>
  <div style="height: 20px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
  <div style="height: 30px; width: 30px;"></div>
</div>
 *
 */

using System;
using NUnit.Framework;

namespace Facebook.CSSLayout
{
    [TestFixture]
    public class CSSLayoutFlexWrapTest
    {
        [Test]
        public void Test_wrap_column()
        {
            CSSNode root = new CSSNode();
            root.Wrap = CSSWrap.Wrap;
            root.StyleHeight = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.StyleWidth = 30;
            root_child0.StyleHeight = 30;
            root.Insert(0, root_child0);

            CSSNode root_child1 = new CSSNode();
            root_child1.StyleWidth = 30;
            root_child1.StyleHeight = 30;
            root.Insert(1, root_child1);

            CSSNode root_child2 = new CSSNode();
            root_child2.StyleWidth = 30;
            root_child2.StyleHeight = 30;
            root.Insert(2, root_child2);

            CSSNode root_child3 = new CSSNode();
            root_child3.StyleWidth = 30;
            root_child3.StyleHeight = 30;
            root.Insert(3, root_child3);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(60, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(30, root_child0.LayoutHeight);

            Assert.AreEqual(0, root_child1.LayoutX);
            Assert.AreEqual(30, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(30, root_child1.LayoutHeight);

            Assert.AreEqual(0, root_child2.LayoutX);
            Assert.AreEqual(60, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(30, root_child3.LayoutX);
            Assert.AreEqual(0, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(60, root.LayoutWidth);
            Assert.AreEqual(100, root.LayoutHeight);

            Assert.AreEqual(30, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(30, root_child0.LayoutHeight);

            Assert.AreEqual(30, root_child1.LayoutX);
            Assert.AreEqual(30, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(30, root_child1.LayoutHeight);

            Assert.AreEqual(30, root_child2.LayoutX);
            Assert.AreEqual(60, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(0, root_child3.LayoutX);
            Assert.AreEqual(0, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);
        }

        [Test]
        public void Test_wrap_row()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.Wrap = CSSWrap.Wrap;
            root.StyleWidth = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.StyleWidth = 30;
            root_child0.StyleHeight = 30;
            root.Insert(0, root_child0);

            CSSNode root_child1 = new CSSNode();
            root_child1.StyleWidth = 30;
            root_child1.StyleHeight = 30;
            root.Insert(1, root_child1);

            CSSNode root_child2 = new CSSNode();
            root_child2.StyleWidth = 30;
            root_child2.StyleHeight = 30;
            root.Insert(2, root_child2);

            CSSNode root_child3 = new CSSNode();
            root_child3.StyleWidth = 30;
            root_child3.StyleHeight = 30;
            root.Insert(3, root_child3);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(60, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(30, root_child0.LayoutHeight);

            Assert.AreEqual(30, root_child1.LayoutX);
            Assert.AreEqual(0, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(30, root_child1.LayoutHeight);

            Assert.AreEqual(60, root_child2.LayoutX);
            Assert.AreEqual(0, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(0, root_child3.LayoutX);
            Assert.AreEqual(30, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(60, root.LayoutHeight);

            Assert.AreEqual(70, root_child0.LayoutX);
            Assert.AreEqual(0, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(30, root_child0.LayoutHeight);

            Assert.AreEqual(40, root_child1.LayoutX);
            Assert.AreEqual(0, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(30, root_child1.LayoutHeight);

            Assert.AreEqual(10, root_child2.LayoutX);
            Assert.AreEqual(0, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(70, root_child3.LayoutX);
            Assert.AreEqual(30, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);
        }

        [Test]
        public void Test_wrap_row_align_items_flex_end()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.AlignItems = CSSAlign.FlexEnd;
            root.Wrap = CSSWrap.Wrap;
            root.StyleWidth = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.StyleWidth = 30;
            root_child0.StyleHeight = 10;
            root.Insert(0, root_child0);

            CSSNode root_child1 = new CSSNode();
            root_child1.StyleWidth = 30;
            root_child1.StyleHeight = 20;
            root.Insert(1, root_child1);

            CSSNode root_child2 = new CSSNode();
            root_child2.StyleWidth = 30;
            root_child2.StyleHeight = 30;
            root.Insert(2, root_child2);

            CSSNode root_child3 = new CSSNode();
            root_child3.StyleWidth = 30;
            root_child3.StyleHeight = 30;
            root.Insert(3, root_child3);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(60, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(20, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);

            Assert.AreEqual(30, root_child1.LayoutX);
            Assert.AreEqual(10, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(20, root_child1.LayoutHeight);

            Assert.AreEqual(60, root_child2.LayoutX);
            Assert.AreEqual(0, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(0, root_child3.LayoutX);
            Assert.AreEqual(30, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(60, root.LayoutHeight);

            Assert.AreEqual(70, root_child0.LayoutX);
            Assert.AreEqual(20, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);

            Assert.AreEqual(40, root_child1.LayoutX);
            Assert.AreEqual(10, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(20, root_child1.LayoutHeight);

            Assert.AreEqual(10, root_child2.LayoutX);
            Assert.AreEqual(0, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(70, root_child3.LayoutX);
            Assert.AreEqual(30, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);
        }

        [Test]
        public void Test_wrap_row_align_items_center()
        {
            CSSNode root = new CSSNode();
            root.FlexDirection = CSSFlexDirection.Row;
            root.AlignItems = CSSAlign.Center;
            root.Wrap = CSSWrap.Wrap;
            root.StyleWidth = 100;

            CSSNode root_child0 = new CSSNode();
            root_child0.StyleWidth = 30;
            root_child0.StyleHeight = 10;
            root.Insert(0, root_child0);

            CSSNode root_child1 = new CSSNode();
            root_child1.StyleWidth = 30;
            root_child1.StyleHeight = 20;
            root.Insert(1, root_child1);

            CSSNode root_child2 = new CSSNode();
            root_child2.StyleWidth = 30;
            root_child2.StyleHeight = 30;
            root.Insert(2, root_child2);

            CSSNode root_child3 = new CSSNode();
            root_child3.StyleWidth = 30;
            root_child3.StyleHeight = 30;
            root.Insert(3, root_child3);
            root.StyleDirection = CSSDirection.LeftToRight;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(60, root.LayoutHeight);

            Assert.AreEqual(0, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);

            Assert.AreEqual(30, root_child1.LayoutX);
            Assert.AreEqual(5, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(20, root_child1.LayoutHeight);

            Assert.AreEqual(60, root_child2.LayoutX);
            Assert.AreEqual(0, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(0, root_child3.LayoutX);
            Assert.AreEqual(30, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);

            root.StyleDirection = CSSDirection.RightToLeft;
            root.CalculateLayout();

            Assert.AreEqual(0, root.LayoutX);
            Assert.AreEqual(0, root.LayoutY);
            Assert.AreEqual(100, root.LayoutWidth);
            Assert.AreEqual(60, root.LayoutHeight);

            Assert.AreEqual(70, root_child0.LayoutX);
            Assert.AreEqual(10, root_child0.LayoutY);
            Assert.AreEqual(30, root_child0.LayoutWidth);
            Assert.AreEqual(10, root_child0.LayoutHeight);

            Assert.AreEqual(40, root_child1.LayoutX);
            Assert.AreEqual(5, root_child1.LayoutY);
            Assert.AreEqual(30, root_child1.LayoutWidth);
            Assert.AreEqual(20, root_child1.LayoutHeight);

            Assert.AreEqual(10, root_child2.LayoutX);
            Assert.AreEqual(0, root_child2.LayoutY);
            Assert.AreEqual(30, root_child2.LayoutWidth);
            Assert.AreEqual(30, root_child2.LayoutHeight);

            Assert.AreEqual(70, root_child3.LayoutX);
            Assert.AreEqual(30, root_child3.LayoutY);
            Assert.AreEqual(30, root_child3.LayoutWidth);
            Assert.AreEqual(30, root_child3.LayoutHeight);
        }

    }
}
