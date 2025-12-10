<template>
  <section id="screenshots" class="py-20 bg-gray-50">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <!-- 标题 -->
      <div class="text-center mb-16">
        <h2 class="section-title">产品截图</h2>
        <p class="section-subtitle">
          直观了解 OpenAsMenu 的界面设计和功能布局
        </p>
      </div>
      
      <!-- 主要截图展示 -->
      <div class="mb-16">
        <div class="bg-white rounded-2xl shadow-xl overflow-hidden">
          <!-- 窗口标题栏 -->
          <div class="bg-gray-100 px-6 py-4 flex items-center justify-between border-b">
            <div class="flex items-center space-x-3">
              <div class="flex space-x-2">
                <div class="w-3 h-3 bg-red-400 rounded-full"></div>
                <div class="w-3 h-3 bg-yellow-400 rounded-full"></div>
                <div class="w-3 h-3 bg-green-400 rounded-full"></div>
              </div>
              <span class="text-sm font-medium text-gray-700">OpenAsMenu - 右键菜单管理工具</span>
            </div>
            <div class="text-xs text-gray-500">v1.0.0</div>
          </div>
          
          <!-- 主界面模拟 -->
          <div class="p-8 bg-gradient-to-br from-gray-50 to-white">
            <div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
              <!-- 左侧配置列表 -->
              <div class="lg:col-span-1">
                <div class="bg-white rounded-lg shadow-md border">
                  <div class="p-4 border-b bg-gray-50 rounded-t-lg">
                    <h3 class="font-semibold text-gray-900">配置列表</h3>
                  </div>
                  <div class="p-4 space-y-3 max-h-80 overflow-y-auto">
                    <div v-for="config in mockConfigs" :key="config.name" 
                         class="flex items-center justify-between p-3 rounded-lg border hover:bg-gray-50 cursor-pointer"
                         :class="{ 'bg-blue-50 border-blue-200': config.selected }">
                      <div class="flex items-center space-x-3">
                        <div class="w-8 h-8 rounded flex items-center justify-center text-white text-sm font-medium"
                             :style="{ backgroundColor: config.color }">
                          {{ config.name.charAt(0) }}
                        </div>
                        <div>
                          <div class="font-medium text-gray-900">{{ config.name }}</div>
                          <div class="text-xs text-gray-500">{{ config.scope }}</div>
                        </div>
                      </div>
                      <div class="text-sm">
                        <span v-if="config.enabled" class="text-green-600">✓ 已启用</span>
                        <span v-else class="text-gray-400">○ 已禁用</span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              
              <!-- 右侧配置详情 -->
              <div class="lg:col-span-2">
                <div class="bg-white rounded-lg shadow-md border">
                  <div class="p-4 border-b bg-gray-50 rounded-t-lg">
                    <h3 class="font-semibold text-gray-900">配置详情</h3>
                  </div>
                  <div class="p-6 space-y-6">
                    <!-- 基本信息 -->
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                      <div>
                        <label class="block text-sm font-medium text-gray-700 mb-2">显示名称</label>
                        <div class="bg-gray-50 rounded-lg px-3 py-2 text-gray-900">VSCode</div>
                      </div>
                      <div>
                        <label class="block text-sm font-medium text-gray-700 mb-2">注册表键名</label>
                        <div class="bg-gray-50 rounded-lg px-3 py-2 text-gray-900">vscode</div>
                      </div>
                    </div>
                    
                    <!-- 程序路径 -->
                    <div>
                      <label class="block text-sm font-medium text-gray-700 mb-2">程序路径</label>
                      <div class="flex space-x-2">
                        <div class="flex-1 bg-gray-50 rounded-lg px-3 py-2 text-gray-900 text-sm">
                          C:\Program Files\Microsoft VS Code\Code.exe
                        </div>
                        <button class="px-4 py-2 bg-primary-600 text-white rounded-lg text-sm hover:bg-primary-700">
                          浏览
                        </button>
                      </div>
                    </div>
                    
                    <!-- 应用范围和状态 -->
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                      <div>
                        <label class="block text-sm font-medium text-gray-700 mb-2">应用范围</label>
                        <div class="space-y-2">
                          <label class="flex items-center">
                            <input type="radio" name="scope" class="text-primary-600" checked>
                            <span class="ml-2 text-sm text-gray-700">目录</span>
                          </label>
                          <label class="flex items-center">
                            <input type="radio" name="scope" class="text-primary-600">
                            <span class="ml-2 text-sm text-gray-700">文件</span>
                          </label>
                        </div>
                      </div>
                      <div>
                        <label class="block text-sm font-medium text-gray-700 mb-2">菜单状态</label>
                        <label class="flex items-center">
                          <input type="checkbox" class="text-primary-600" checked>
                          <span class="ml-2 text-sm text-gray-700">启用右键菜单</span>
                        </label>
                      </div>
                    </div>
                    
                    <!-- 操作按钮 -->
                    <div class="flex space-x-3 pt-4 border-t">
                      <button class="btn-primary text-sm">应用更改</button>
                      <button class="bg-gray-200 hover:bg-gray-300 text-gray-800 font-medium py-2 px-4 rounded-lg text-sm transition-colors">
                        重置
                      </button>
                      <button class="bg-red-100 hover:bg-red-200 text-red-700 font-medium py-2 px-4 rounded-lg text-sm transition-colors">
                        删除配置
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      
      <!-- 功能亮点截图 -->
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        <!-- 右键菜单效果 -->
        <div class="bg-white rounded-xl shadow-lg overflow-hidden">
          <div class="p-6">
            <h3 class="text-lg font-semibold text-gray-900 mb-4">右键菜单效果</h3>
            <div class="bg-gray-100 rounded-lg p-4">
              <div class="bg-white rounded-lg shadow-lg border p-2 max-w-48">
                <div class="space-y-1">
                  <div class="px-3 py-2 hover:bg-blue-50 rounded text-sm cursor-pointer flex items-center">
                    <span class="w-4 h-4 bg-blue-500 rounded mr-2"></span>
                    用 VSCode 打开
                  </div>
                  <div class="px-3 py-2 hover:bg-purple-50 rounded text-sm cursor-pointer flex items-center">
                    <span class="w-4 h-4 bg-purple-500 rounded mr-2"></span>
                    用 Cursor 打开
                  </div>
                  <div class="border-t my-1"></div>
                  <div class="px-3 py-2 hover:bg-gray-50 rounded text-sm cursor-pointer">
                    复制
                  </div>
                  <div class="px-3 py-2 hover:bg-gray-50 rounded text-sm cursor-pointer">
                    属性
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        
        <!-- 状态监控 -->
        <div class="bg-white rounded-xl shadow-lg overflow-hidden">
          <div class="p-6">
            <h3 class="text-lg font-semibold text-gray-900 mb-4">实时状态监控</h3>
            <div class="space-y-3">
              <div class="flex items-center justify-between p-3 bg-green-50 rounded-lg border border-green-200">
                <div class="flex items-center space-x-2">
                  <div class="w-2 h-2 bg-green-500 rounded-full"></div>
                  <span class="text-sm text-green-800">VSCode</span>
                </div>
                <span class="text-xs text-green-600">运行正常</span>
              </div>
              <div class="flex items-center justify-between p-3 bg-yellow-50 rounded-lg border border-yellow-200">
                <div class="flex items-center space-x-2">
                  <div class="w-2 h-2 bg-yellow-500 rounded-full"></div>
                  <span class="text-sm text-yellow-800">PyCharm</span>
                </div>
                <span class="text-xs text-yellow-600">路径无效</span>
              </div>
              <div class="flex items-center justify-between p-3 bg-gray-50 rounded-lg border border-gray-200">
                <div class="flex items-center space-x-2">
                  <div class="w-2 h-2 bg-gray-400 rounded-full"></div>
                  <span class="text-sm text-gray-600">IDEA</span>
                </div>
                <span class="text-xs text-gray-500">已禁用</span>
              </div>
            </div>
          </div>
        </div>
        
        <!-- 批量操作 -->
        <div class="bg-white rounded-xl shadow-lg overflow-hidden">
          <div class="p-6">
            <h3 class="text-lg font-semibold text-gray-900 mb-4">批量操作</h3>
            <div class="space-y-3">
              <div class="flex items-center justify-between p-2 border rounded">
                <label class="flex items-center">
                  <input type="checkbox" class="mr-2" checked>
                  <span class="text-sm">VSCode</span>
                </label>
                <span class="text-xs text-green-600">✓</span>
              </div>
              <div class="flex items-center justify-between p-2 border rounded">
                <label class="flex items-center">
                  <input type="checkbox" class="mr-2" checked>
                  <span class="text-sm">Cursor</span>
                </label>
                <span class="text-xs text-green-600">✓</span>
              </div>
              <div class="flex items-center justify-between p-2 border rounded">
                <label class="flex items-center">
                  <input type="checkbox" class="mr-2">
                  <span class="text-sm">PyCharm</span>
                </label>
                <span class="text-xs text-gray-400">○</span>
              </div>
              <div class="flex space-x-2 pt-2">
                <button class="flex-1 bg-green-100 text-green-700 py-1 px-2 rounded text-xs">
                  批量启用
                </button>
                <button class="flex-1 bg-red-100 text-red-700 py-1 px-2 rounded text-xs">
                  批量禁用
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'ScreenshotsSection',
  setup() {
    const mockConfigs = [
      { name: 'VSCode', color: '#007ACC', scope: '目录', enabled: true, selected: true },
      { name: 'PyCharm', color: '#000000', scope: '目录', enabled: false, selected: false },
      { name: 'IDEA', color: '#000000', scope: '目录', enabled: false, selected: false },
      { name: 'Cursor', color: '#000000', scope: '目录', enabled: true, selected: false },
      { name: 'Notepad++', color: '#90E59A', scope: '文件', enabled: false, selected: false },
      { name: 'Sublime', color: '#FF9800', scope: '文件', enabled: false, selected: false }
    ]
    
    return {
      mockConfigs
    }
  }
}
</script>
