//
//  CSSLayoutTests.swift
//  CSSLayoutTests
//
//  Created by Stefano J. Attardi on 11/3/16.
//  Copyright © 2016 ffByOne Inc. All rights reserved.
//

import XCTest
import CSSLayout

class CSSLayoutTests: XCTestCase {
    
  override func setUp() {
    super.setUp()
  }
  
  override func tearDown() {
    super.tearDown()
  }
  
  func testBasics() {
    let parent = Node(flexDirection: .row)
    let child1 = Node(width: 100, height: 100)
    let child2 = Node(measure: { _ in
      CGSize(width: 50, height: 200)
    })
    let child3 = Node(alignSelf: .stretch, width: 100)

    parent.addChild(child1)
    parent.addChild(child2)
    parent.addChild(child3)

    parent.layout()

    XCTAssertEqual(parent.frame, CGRect(x: 0, y: 0, width: 250, height: 200))
    XCTAssertEqual(child1.frame, CGRect(x: 0, y: 0, width: 100, height: 100))
    XCTAssertEqual(child2.frame, CGRect(x: 100, y: 0, width: 50, height: 200))
    XCTAssertEqual(child3.frame, CGRect(x: 150, y: 0, width: 100, height: 200))
  }

  func testMeasureUpdate() {
    let parent = Node(flexDirection: .row)
    let child1 = Node(width: 100, height: 100)
    let child2 = Node(alignSelf: .flexStart, measure: { _ in
      CGSize(width: 50, height: 200)
    })
    let child3 = Node(alignSelf: .stretch, width: 100)

    parent.addChild(child1)
    parent.addChild(child2)
    parent.addChild(child3)

    parent.layout()

    child2.measure = { _ in
      CGSize(width: 200, height: 20)
    }

    child2.dirty = true
    parent.layout()

    XCTAssert(!child2.dirty)
    XCTAssertEqual(parent.frame, CGRect(x: 0, y: 0, width: 400, height: 100))
    XCTAssertEqual(child1.frame, CGRect(x: 0, y: 0, width: 100, height: 100))
    XCTAssertEqual(child2.frame, CGRect(x: 100, y: 0, width: 200, height: 20))
    XCTAssertEqual(child3.frame, CGRect(x: 300, y: 0, width: 100, height: 100))
  }

  func testChildRetention() {
    let parent = Node(flexDirection: .row)
    parent.addChild(Node(measure: { _ in
      CGSize(width: 50, height: 200)
    }))

    parent.layout()

    XCTAssertEqual(parent.frame, CGRect(x: 0, y: 0, width: 50, height: 200))
  }

  func testUpdate() {
    let parent = Node(flexDirection: .row, width: 300)
    let child = Node(flexGrow: 1, measure: { _ in
      CGSize(width: 50, height: 200)
    })
    parent.addChild(child)

    parent.layout()

    XCTAssertEqual(parent.frame, CGRect(x: 0, y: 0, width: 300, height: 200))
    XCTAssertEqual(child.frame, CGRect(x: 0, y: 0, width: 300, height: 200))

    let newParent = Node(flexDirection: .row, width: 400)

    parent.update(newParent)

    parent.layout()

    XCTAssertEqual(parent.frame, CGRect(x: 0, y: 0, width: 400, height: 200))
    XCTAssertEqual(child.frame, CGRect(x: 0, y: 0, width: 400, height: 200))
  }

  func testMeasureMode() {
    let parent = Node(measure: { size in size })
    parent.layout()
    XCTAssertEqual(parent.frame.width, CGFloat.infinity)
    XCTAssertEqual(parent.frame.height, CGFloat.infinity)
  }
  
  func testPerformanceExample() {
    // This is an example of a performance test case.
    //self.measure {
      // Put the code you want to measure the time of here.
    //}
  }
    
}
