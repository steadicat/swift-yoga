// ©2016-present ffByOne, Inc.

import CCSSLayout

public enum Direction: UInt32 {
  case inherit = 0
  case ltr
  case rtl

  fileprivate var value: CSSDirection {
    return CSSDirection(self.rawValue)
  }
}

public enum FlexDirection: UInt32 {
  case column = 0
  case columnReverse
  case row
  case rowReverse

  fileprivate var value: CSSFlexDirection {
    return CSSFlexDirection(self.rawValue)
  }
}

public enum Justify: UInt32 {
  case flexStart = 0
  case center
  case flexEnd
  case spaceBetween
  case spaceAround

  fileprivate var value: CSSJustify {
    return CSSJustify(self.rawValue)
  }
}

public enum Overflow: UInt32 {
  case visible = 0
  case hidden
  case scroll

  fileprivate var value: CSSOverflow {
    return CSSOverflow(self.rawValue)
  }
}

public enum Align: UInt32 {
  case auto = 0
  case flexStart
  case center
  case flexEnd
  case stretch

  fileprivate var value: CSSAlign {
    return CSSAlign(self.rawValue)
  }
}

public enum PositionType: UInt32 {
  case relative = 0
  case absolute

  fileprivate var value: CSSPositionType {
    return CSSPositionType(self.rawValue)
  }
}

public enum WrapType: UInt32 {
  case noWrap = 0
  case wrap

  fileprivate var value: CSSWrapType {
    return CSSWrapType(self.rawValue)
  }
}

public struct Edges {
  let left: CGFloat?
  let top: CGFloat?
  let right: CGFloat?
  let bottom: CGFloat?
  let start: CGFloat?
  let end: CGFloat?
  let horizontal: CGFloat?
  let vertical: CGFloat?
  let all: CGFloat?

  public init(
    left: CGFloat? = nil,
    top: CGFloat? = nil,
    right: CGFloat? = nil,
    bottom: CGFloat? = nil,
    start: CGFloat? = nil,
    end: CGFloat? = nil,
    horizontal: CGFloat? = nil,
    vertical: CGFloat? = nil,
    all: CGFloat? = nil
  ) {
    self.left = left
    self.top = top
    self.right = right
    self.bottom = bottom
    self.start = start
    self.end = end
    self.horizontal = horizontal
    self.vertical = vertical
    self.all = all
  }

  fileprivate func apply(node: CSSNodeRef!, setter: (CSSNodeRef, CSSEdge, Float) -> Void) {
    if let left = left {
      setter(node, CSSEdgeLeft, Float(left))
    }
    if let top = top {
      setter(node, CSSEdgeTop, Float(top))
    }
    if let right = right {
      setter(node, CSSEdgeRight, Float(right))
    }
    if let bottom = bottom {
      setter(node, CSSEdgeBottom, Float(bottom))
    }
    if let start = start {
      setter(node, CSSEdgeStart, Float(start))
    }
    if let end = end {
      setter(node, CSSEdgeEnd, Float(end))
    }
    if let horizontal = horizontal {
      setter(node, CSSEdgeHorizontal, Float(horizontal))
    }
    if let vertical = vertical {
      setter(node, CSSEdgeVertical, Float(vertical))
    }
    if let all = all {
      setter(node, CSSEdgeAll, Float(all))
    }
  }
}

public class Node {

  private let node: CSSNodeRef
  private var children: [Node] = []

  public init(
    direction: Direction = .inherit,
    flexDirection: FlexDirection = .column,
    justifyContent: Justify = .flexStart,
    alignContent: Align = .flexStart,
    alignItems: Align = .stretch,
    alignSelf: Align = .auto,
    positionType: PositionType = .relative,
    flexWrap: WrapType = .noWrap,
    overflow: Overflow = .visible,
    flex: CGFloat? = nil,
    flexGrow: CGFloat? = nil,
    flexShrink: CGFloat? = nil,
    flexBasis: CGFloat? = nil,
    margin: Edges = Edges(),
    position: Edges = Edges(),
    padding: Edges = Edges(),
    border: Edges = Edges(),
    width: CGFloat? = nil,
    height: CGFloat? = nil,
    minWidth: CGFloat? = nil,
    minHeight: CGFloat? = nil,
    maxWidth: CGFloat? = nil,
    maxHeight: CGFloat? = nil,
    measure: ((CGSize) -> CGSize)? = nil
  ) {
    node = CSSNodeNew()

    CSSNodeStyleSetDirection(node, direction.value)
    CSSNodeStyleSetFlexDirection(node, flexDirection.value)
    CSSNodeStyleSetJustifyContent(node, justifyContent.value)
    CSSNodeStyleSetAlignContent(node, alignContent.value)
    CSSNodeStyleSetAlignItems(node, alignItems.value)

    CSSNodeStyleSetAlignSelf(node, alignSelf.value)
    CSSNodeStyleSetPositionType(node, positionType.value)
    CSSNodeStyleSetFlexWrap(node, flexWrap.value)
    CSSNodeStyleSetOverflow(node, overflow.value)

    if let flex = flex {
      CSSNodeStyleSetFlex(node, Float(flex))
    }
    if let flexGrow = flexGrow {
      CSSNodeStyleSetFlexGrow(node, Float(flexGrow))
    }
    if let flexShrink = flexShrink {
      CSSNodeStyleSetFlexShrink(node, Float(flexShrink))
    }
    if let flexBasis = flexBasis {
      CSSNodeStyleSetFlexBasis(node, Float(flexBasis))
    }

    margin.apply(node: node, setter: CSSNodeStyleSetMargin)
    position.apply(node: node, setter: CSSNodeStyleSetPosition)
    padding.apply(node: node, setter: CSSNodeStyleSetPadding)
    border.apply(node: node, setter: CSSNodeStyleSetBorder)

    if let width = width {
      CSSNodeStyleSetWidth(node, Float(width))
    }
    if let height = height {
      CSSNodeStyleSetHeight(node, Float(height))
    }
    if let minWidth = minWidth {
      CSSNodeStyleSetMinWidth(node, Float(minWidth))
    }
    if let minHeight = minHeight {
      CSSNodeStyleSetMinHeight(node, Float(minHeight))
    }
    if let maxWidth = maxWidth {
      CSSNodeStyleSetMaxWidth(node, Float(maxWidth))
    }
    if let maxHeight = maxHeight {
      CSSNodeStyleSetMaxHeight(node, Float(maxHeight))
    }

    self.measure = measure
    self.updateMeasureFunc()
  }

  deinit {
    CSSNodeSetContext(node, nil)
  }

  public func addChild(_ child: Node) {
    children.append(child)
    CSSNodeInsertChild(node, child.node, CSSNodeChildCount(node))
  }

  public func removeChild(_ child: Node) {
    guard let index = children.index(where: { $0.node == child.node }) else {
      return
    }
    assert(CSSNodeChildCount(node) > 0)
    children.remove(at: index)
    CSSNodeRemoveChild(node, child.node)
  }

  public func update(_ other: Node) {
    precondition(other.children.count == 0, "Do not add children to nodes used to update other nodes: those are supposed to be throwaway")

    CSSNodeStyleSetDirection(node, CSSNodeStyleGetDirection(other.node))
    CSSNodeStyleSetFlexDirection(node, CSSNodeStyleGetFlexDirection(other.node))
    CSSNodeStyleSetJustifyContent(node, CSSNodeStyleGetJustifyContent(other.node))
    CSSNodeStyleSetAlignContent(node, CSSNodeStyleGetAlignContent(other.node))
    CSSNodeStyleSetAlignItems(node, CSSNodeStyleGetAlignItems(other.node))

    CSSNodeStyleSetAlignSelf(node, CSSNodeStyleGetAlignSelf(other.node))
    CSSNodeStyleSetPositionType(node, CSSNodeStyleGetPositionType(other.node))
    CSSNodeStyleSetFlexWrap(node, CSSNodeStyleGetFlexWrap(other.node))
    CSSNodeStyleSetOverflow(node, CSSNodeStyleGetOverflow(other.node))

    CSSNodeStyleSetFlexGrow(node, CSSNodeStyleGetFlexGrow(other.node))
    CSSNodeStyleSetFlexShrink(node, CSSNodeStyleGetFlexShrink(other.node))
    CSSNodeStyleSetFlexBasis(node, CSSNodeStyleGetFlexBasis(other.node))

    copyEdges(from: other.node, to: node, getter: CSSNodeStyleGetMargin, setter: CSSNodeStyleSetMargin)
    copyEdges(from: other.node, to: node, getter: CSSNodeStyleGetPosition, setter: CSSNodeStyleSetPosition)
    copyEdges(from: other.node, to: node, getter: CSSNodeStyleGetPadding, setter: CSSNodeStyleSetPadding)
    copyEdges(from: other.node, to: node, getter: CSSNodeStyleGetBorder, setter: CSSNodeStyleSetBorder)

    CSSNodeStyleSetWidth(node, CSSNodeStyleGetWidth(other.node))
    CSSNodeStyleSetHeight(node, CSSNodeStyleGetHeight(other.node))
    CSSNodeStyleSetMinWidth(node, CSSNodeStyleGetMinWidth(other.node))
    CSSNodeStyleSetMinHeight(node, CSSNodeStyleGetMinHeight(other.node))
    CSSNodeStyleSetMaxWidth(node, CSSNodeStyleGetMaxWidth(other.node))
    CSSNodeStyleSetMaxHeight(node, CSSNodeStyleGetMaxHeight(other.node))

    self.measure = other.measure

    if self.measure != nil && CSSNodeIsDirty(other.node) {
      CSSNodeMarkDirty(node)
    }
  }

  public var measure: ((CGSize) -> CGSize)? {
    didSet {
      self.updateMeasureFunc()
    }
  }

  private func updateMeasureFunc() {
    guard measure != nil else {
      CSSNodeSetContext(node, nil)
      return
    }
    CSSNodeSetContext(node, Unmanaged<Node>.passUnretained(self).toOpaque())
    CSSNodeSetMeasureFunc(node) { (node: Optional<OpaquePointer>, width: Float, widthMode: CSSMeasureMode, height: Float, heightMode: CSSMeasureMode) -> CSSSize in
      // TODO: use modes?
      guard let context = CSSNodeGetContext(node) else {
        print("Warning: called measure on a node that is now gone")
        return CSSSize(width: width, height: height)
      }
      guard let measure = Unmanaged<Node>.fromOpaque(context).takeUnretainedValue().measure else {
        print("Warning: called measure on a node without a measure function")
        return CSSSize(width: width, height: height)
      }
      let size = measure(CGSize(width: CGFloat(width), height: CGFloat(height)))
      return CSSSize(width: Float(size.width), height: Float(size.height))
    }
  }

  public var dirty: Bool {
    get {
      return CSSNodeIsDirty(node)
    }
    set {
      CSSNodeMarkDirty(node)
    }
  }

  public func layout(availableWidth: CGFloat? = nil, availableHeight: CGFloat? = nil, parentDirection: Direction = .ltr) {
    CSSNodeCalculateLayout(
      node,
      availableWidth != nil ? Float(availableWidth!) : .nan,
      availableHeight != nil ? Float(availableHeight!) : .nan,
      parentDirection.value
    )
  }

  public var frame: CGRect {
    return CGRect(
      x: CGFloat(CSSNodeLayoutGetLeft(node)),
      y: CGFloat(CSSNodeLayoutGetTop(node)),
      width: CGFloat(CSSNodeLayoutGetWidth(node)),
      height: CGFloat(CSSNodeLayoutGetHeight(node))
    )
  }
}

func copyEdges(from: CSSNodeRef!, to: CSSNodeRef!, getter: (CSSNodeRef, CSSEdge) -> Float, setter: (CSSNodeRef, CSSEdge, Float) -> Void) {
  setter(to, CSSEdgeLeft, getter(from, CSSEdgeLeft))
  setter(to, CSSEdgeTop, getter(from, CSSEdgeTop))
  setter(to, CSSEdgeRight, getter(from, CSSEdgeRight))
  setter(to, CSSEdgeBottom, getter(from, CSSEdgeBottom))
  setter(to, CSSEdgeStart, getter(from, CSSEdgeStart))
  setter(to, CSSEdgeEnd, getter(from, CSSEdgeEnd))
}
