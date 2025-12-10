# MenuManager 官网

这是 MenuManager 项目的官方网站，使用 Vue 3 + Vite + Tailwind CSS 构建。

**在线访问**: https://pengcunfu.github.io/MenuManager/

## 项目简介

MenuManager 是一个专业的 Windows 右键菜单管理工具，帮助用户轻松管理和配置右键菜单项。本网站为该工具提供产品介绍、功能展示、下载和使用说明等服务。

## 技术栈

- **Vue 3** - 渐进式JavaScript框架
- **Vite** - 现代化的构建工具
- **Tailwind CSS** - 实用优先的CSS框架
- **@vueuse/core** - Vue组合式API工具集

## 功能特性

- 📱 **响应式设计** - 完美适配各种设备
- 🎨 **现代化UI** - 美观的界面设计和流畅的动画
- 🚀 **高性能** - 基于Vite的快速构建和热重载
- 🔧 **易于维护** - 组件化开发，代码结构清晰
- 🌟 **用户体验** - 直观的导航和丰富的交互效果

## 网站结构

```
src/
├── components/          # Vue组件
│   ├── Navbar.vue      # 导航栏
│   ├── HeroSection.vue # 英雄区域
│   ├── FeaturesSection.vue # 功能特性
│   ├── ScreenshotsSection.vue # 产品截图
│   ├── DownloadSection.vue # 下载区域
│   ├── GuideSection.vue # 使用说明
│   └── Footer.vue      # 页脚
├── style.css           # 全局样式
├── main.js            # 应用入口
└── App.vue            # 根组件
```

## 快速开始

### 环境要求

- Node.js 16+ 
- npm 或 yarn

### 安装依赖

```bash
npm install
```

### 开发服务器

```bash
npm run dev
```

访问 http://localhost:3000 查看网站

### 构建生产版本

```bash
npm run build
```

### 预览生产版本

```bash
npm run preview
```

## 网站内容

### 首页 (Hero Section)
- 产品介绍和核心价值主张
- 主要功能亮点展示
- 行动号召按钮
- 产品预览界面

### 功能特性 (Features)
- 详细的功能介绍
- 技术架构展示
- 支持的编辑器列表
- 功能亮点说明

### 产品截图 (Screenshots)
- 主界面展示
- 功能演示
- 用户界面细节
- 操作流程展示

### 下载区域 (Download)
- 多版本下载选项
- 系统要求说明
- 下载统计信息
- 安全保证说明

### 使用说明 (Guide)
- 详细的使用步骤
- 常见问题解答
- 技术支持信息
- 视频教程入口

## 样式系统

项目使用 Tailwind CSS 作为样式框架，并定义了以下自定义样式：

- **主色调**: Primary Blue (#3b82f6)
- **动画效果**: Float, Fade-in, Slide-up
- **组件样式**: 按钮、卡片、标题等复用样式
- **响应式布局**: 移动端优先的响应式设计

## 部署

### 静态部署

构建后的 `dist` 文件夹可以部署到任何静态文件服务器：

- GitHub Pages
- Netlify
- Vercel
- 传统Web服务器

### 环境变量

如需配置特定环境，可以创建 `.env` 文件：

```env
VITE_APP_TITLE=MenuManager
VITE_API_URL=https://api.example.com
```

## 开发指南

### 添加新组件

1. 在 `src/components/` 目录下创建新组件
2. 在 `App.vue` 中导入并使用
3. 更新导航链接（如需要）

### 修改样式

- 全局样式：编辑 `src/style.css`
- 组件样式：在组件内使用 Tailwind 类名
- 自定义样式：在 `tailwind.config.js` 中扩展

### 优化性能

- 使用 Vue 3 的 Composition API
- 合理使用 v-show 和 v-if
- 图片懒加载
- 代码分割

## 贡献

欢迎提交问题和改进建议！

1. Fork 项目
2. 创建功能分支
3. 提交更改
4. 推送到分支
5. 创建 Pull Request

## 许可证

本项目基于 MIT 许可证开源。

## 联系方式

- 项目主页：[GitHub Repository]
- 问题反馈：[GitHub Issues]
- 邮箱：your-email@example.com

---

感谢使用 MenuManager！
