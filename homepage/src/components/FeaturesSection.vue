<template>
  <section id="features" class="py-20 bg-white">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <!-- 标题 -->
      <div class="text-center mb-16">
        <h2 class="section-title">强大的功能特性</h2>
        <p class="section-subtitle">
          OpenAsMenu 提供了全面的右键菜单管理功能，让您的工作更加高效便捷
        </p>
      </div>
      
      <!-- 主要功能网格 -->
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8 mb-16">
        <!-- 功能卡片 -->
        <div v-for="feature in features" :key="feature.id" 
             class="card group hover:scale-105 transform transition-all duration-300">
          <div class="flex items-center mb-4">
            <div class="w-12 h-12 bg-primary-100 rounded-lg flex items-center justify-center group-hover:bg-primary-200 transition-colors">
              <component :is="feature.icon" class="w-6 h-6 text-primary-600"/>
            </div>
            <h3 class="text-xl font-semibold text-gray-900 ml-4">{{ feature.title }}</h3>
          </div>
          <p class="text-gray-600 leading-relaxed">{{ feature.description }}</p>
          
          <!-- 功能亮点 -->
          <div class="mt-4 space-y-2">
            <div v-for="highlight in feature.highlights" :key="highlight" 
                 class="flex items-center text-sm text-gray-500">
              <svg class="w-4 h-4 text-green-500 mr-2" fill="currentColor" viewBox="0 0 20 20">
                <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"/>
              </svg>
              {{ highlight }}
            </div>
          </div>
        </div>
      </div>
      
      <!-- 技术架构 -->
      <div class="bg-gray-50 rounded-2xl p-8 mb-16">
        <div class="text-center mb-8">
          <h3 class="text-2xl font-bold text-gray-900 mb-4">技术架构</h3>
          <p class="text-gray-600">基于现代化技术栈构建，确保性能和稳定性</p>
        </div>
        
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
          <div v-for="tech in technologies" :key="tech.name" 
               class="bg-white rounded-lg p-6 text-center hover:shadow-lg transition-shadow">
            <div class="w-16 h-16 mx-auto mb-4 bg-gray-100 rounded-lg flex items-center justify-center">
              <span class="text-2xl">{{ tech.icon }}</span>
            </div>
            <h4 class="font-semibold text-gray-900 mb-2">{{ tech.name }}</h4>
            <p class="text-sm text-gray-600">{{ tech.description }}</p>
          </div>
        </div>
      </div>
      
      <!-- 支持的编辑器 -->
      <div class="text-center mb-8">
        <h3 class="text-2xl font-bold text-gray-900 mb-4">支持的编辑器和IDE</h3>
        <p class="text-gray-600 mb-8">内置多种流行编辑器的预设配置，开箱即用</p>
      </div>
      
      <div class="grid grid-cols-2 md:grid-cols-4 lg:grid-cols-6 gap-6">
        <div v-for="editor in editors" :key="editor.name" 
             class="bg-white rounded-lg p-4 text-center hover:shadow-lg transition-all duration-300 hover:scale-105 border">
          <div class="w-12 h-12 mx-auto mb-3 rounded-lg flex items-center justify-center"
               :style="{ backgroundColor: editor.color + '20' }">
            <span class="text-2xl">{{ editor.icon }}</span>
          </div>
          <h4 class="font-medium text-gray-900 text-sm">{{ editor.name }}</h4>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { defineComponent } from 'vue'

// 图标组件
const MenuIcon = {
  template: `
    <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h7"/>
    </svg>
  `
}

const SettingsIcon = {
  template: `
    <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10.325 4.317c.426-1.756 2.924-1.756 3.35 0a1.724 1.724 0 002.573 1.066c1.543-.94 3.31.826 2.37 2.37a1.724 1.724 0 001.065 2.572c1.756.426 1.756 2.924 0 3.35a1.724 1.724 0 00-1.066 2.573c.94 1.543-.826 3.31-2.37 2.37a1.724 1.724 0 00-2.572 1.065c-.426 1.756-2.924 1.756-3.35 0a1.724 1.724 0 00-2.573-1.066c-1.543.94-3.31-.826-2.37-2.37a1.724 1.724 0 00-1.065-2.572c-1.756-.426-1.756-2.924 0-3.35a1.724 1.724 0 001.066-2.573c-.94-1.543.826-3.31 2.37-2.37.996.608 2.296.07 2.572-1.065z"/>
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"/>
    </svg>
  `
}

const ShieldIcon = {
  template: `
    <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z"/>
    </svg>
  `
}

const EyeIcon = {
  template: `
    <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"/>
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"/>
    </svg>
  `
}

const DocumentIcon = {
  template: `
    <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"/>
    </svg>
  `
}

const LightningIcon = {
  template: `
    <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z"/>
    </svg>
  `
}

export default defineComponent({
  name: 'FeaturesSection',
  components: {
    MenuIcon,
    SettingsIcon,
    ShieldIcon,
    EyeIcon,
    DocumentIcon,
    LightningIcon
  },
  setup() {
    const features = [
      {
        id: 1,
        title: '右键菜单管理',
        icon: 'MenuIcon',
        description: '轻松添加、删除和管理Windows右键菜单项，支持文件和目录两种应用场景。',
        highlights: ['一键添加/删除', '支持文件和目录', '批量操作']
      },
      {
        id: 2,
        title: '智能配置',
        icon: 'SettingsIcon',
        description: '提供直观的配置界面，支持自定义菜单名称、程序路径和注册表键名。',
        highlights: ['可视化配置', '路径验证', '配置导入导出']
      },
      {
        id: 3,
        title: '安全可靠',
        icon: 'ShieldIcon',
        description: '自动管理员权限检测，安全的注册表操作，确保系统稳定性。',
        highlights: ['权限管理', '安全操作', '系统保护']
      },
      {
        id: 4,
        title: '实时监控',
        icon: 'EyeIcon',
        description: '实时检测菜单项状态，自动刷新配置状态，提供准确的反馈信息。',
        highlights: ['状态检测', '自动刷新', '实时反馈']
      },
      {
        id: 5,
        title: '配置管理',
        icon: 'DocumentIcon',
        description: '支持配置文件的保存和加载，方便备份和迁移配置信息。',
        highlights: ['配置保存', '数据备份', '设置迁移']
      },
      {
        id: 6,
        title: '高效便捷',
        icon: 'LightningIcon',
        description: '现代化的WPF界面，响应迅速的操作体验，提升工作效率。',
        highlights: ['现代界面', '快速响应', '用户友好']
      }
    ]
    
    const technologies = [
      {
        name: 'C# WPF',
        icon: '🏗️',
        description: '现代化桌面应用框架'
      },
      {
        name: '.NET 8',
        icon: '⚡',
        description: '最新的.NET运行时'
      },
      {
        name: 'JSON配置',
        icon: '📄',
        description: '轻量级配置文件'
      },
      {
        name: 'Registry API',
        icon: '🔧',
        description: 'Windows注册表操作'
      }
    ]
    
    const editors = [
      { name: 'VSCode', icon: '📝', color: '#007ACC' },
      { name: 'PyCharm', icon: '🐍', color: '#000000' },
      { name: 'IDEA', icon: '💡', color: '#000000' },
      { name: 'PhpStorm', icon: '🌐', color: '#B345F1' },
      { name: 'GoLand', icon: '🔵', color: '#00ADD8' },
      { name: 'Cursor', icon: '🎯', color: '#000000' },
      { name: 'Notepad++', icon: '📄', color: '#90E59A' },
      { name: 'Sublime', icon: '🎨', color: '#FF9800' },
      { name: '记事本', icon: '📋', color: '#0078D4' },
      { name: 'Trae', icon: '🔮', color: '#6366F1' }
    ]
    
    return {
      features,
      technologies,
      editors
    }
  }
})
</script>
