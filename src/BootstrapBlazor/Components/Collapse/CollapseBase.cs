﻿using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor.Components
{
    /// <summary>
    ///折叠组件
    /// </summary>
    public abstract class CollapseBase : BootstrapComponentBase
    {
        /// <summary>
        /// 获得 按钮样式集合
        /// </summary>
        protected string? ClassName => CssBuilder.Default("btn")
            .AddClass($"btn-{Color.ToDescriptionString()}", Color != Color.None)
            .AddClass($"btn-{Size.ToDescriptionString()}", Size != Size.None)
            .AddClass("collapsed", IsCollapsed)
            .AddClass("disabled", IsDisabled)
            .AddClassFromAttributes(AdditionalAttributes)
            .Build();

        /// <summary>
        /// 是否收缩折叠面板
        /// </summary>
        [Parameter] public bool IsCollapsed { get; set; } = true;

        /// <summary>
        /// 获得/设置 按钮颜色
        /// </summary>
        [Parameter] public Color Color { get; set; } = Color.Primary;

        /// <summary>
        ///获得/设置 按钮大小
        /// </summary>
        [Parameter] public Size Size { get; set; } = Size.None;

        /// <summary>
        /// 获得 展开 Collapsed 属性
        /// </summary>
        protected string? Collapsed => !IsCollapsed ? "true" : "false";

        /// <summary>
        /// 获得 是否禁止 disabled 属性
        /// </summary>
        protected string? Disabled => IsDisabled ? "true" : null;

        /// <summary>
        /// 获得 折叠内容组件客户端高度
        /// </summary>
        protected CollapseBody? CollapseContent { get; set; }

        /// <summary>
        /// 获得 显示文字
        /// </summary>
        protected string? Title => IsCollapsed ? ExpandedText : CollapsedText;

        /// <summary>
        /// 获得/设置 是否禁用
        /// </summary>
        [Parameter] public bool IsDisabled { get; set; }

        /// <summary>
        /// 子组件
        /// </summary>
        [Parameter] public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// 获得/设置 折叠后显示的文字
        /// </summary>
        [Parameter] public string? CollapsedText { get; set; } = "展开";

        /// <summary>
        /// 获得/设置 展开后显示的文字
        /// </summary>
        [Parameter] public string? ExpandedText { get; set; } = "折叠";

        /// <summary>
        /// 点击选择框方法
        /// </summary>
        protected void OnClick()
        {
            IsCollapsed = !IsCollapsed;

            CollapseContent?.DoAnimations(IsCollapsed);
        }
    }
}
