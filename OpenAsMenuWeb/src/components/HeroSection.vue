<template>
  <section id="home" class="relative bg-gradient-to-br from-primary-50 to-blue-50 py-20">
    <!-- 背景装饰 -->
    <div class="absolute inset-0 overflow-hidden">
      <div class="absolute -top-40 -right-32 w-80 h-80 bg-primary-200 rounded-full opacity-20 animate-float"></div>
      <div class="absolute -bottom-40 -left-32 w-96 h-96 bg-blue-200 rounded-full opacity-20 animate-float" style="animation-delay: 1s;"></div>
    </div>
    
    <div class="relative max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="text-center">
        <!-- 主标题 -->
        <h1 class="text-4xl md:text-6xl font-bold text-gray-900 mb-6 animate-fade-in">
          <span class="text-primary-600">OpenAsMenu</span>
          <br>
          <span class="text-3xl md:text-5xl">专业的右键菜单管理工具</span>
        </h1>
        
        <!-- 副标题 -->
        <p class="text-xl text-gray-600 mb-8 max-w-3xl mx-auto animate-slide-up" style="animation-delay: 0.2s;">
          轻松管理Windows右键菜单，一键添加您喜爱的编辑器和工具到右键菜单中，提升工作效率
        </p>
        
        <!-- 特性标签 -->
        <div class="flex flex-wrap justify-center gap-3 mb-10 animate-slide-up" style="animation-delay: 0.4s;">
          <span class="bg-white text-primary-600 px-4 py-2 rounded-full text-sm font-medium shadow-md">
            🛡️ 安全可靠
          </span>
          <span class="bg-white text-primary-600 px-4 py-2 rounded-full text-sm font-medium shadow-md">
            🎨 现代化界面
          </span>
          <span class="bg-white text-primary-600 px-4 py-2 rounded-full text-sm font-medium shadow-md">
            ⚡ 高效便捷
          </span>
          <span class="bg-white text-primary-600 px-4 py-2 rounded-full text-sm font-medium shadow-md">
            🔧 易于配置
          </span>
        </div>
        
        <!-- 行动按钮 -->
        <div class="flex flex-col sm:flex-row justify-center gap-4 mb-12 animate-slide-up" style="animation-delay: 0.6s;">
          <a href="#download" class="btn-primary inline-flex items-center">
            <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 10v6m0 0l-3-3m3 3l3-3m2 8H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"/>
            </svg>
            立即下载
          </a>
          <a href="#features" class="btn-secondary inline-flex items-center">
            <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"/>
            </svg>
            了解更多
          </a>
        </div>
        
        <!-- 产品预览图 -->
        <div class="relative max-w-4xl mx-auto animate-slide-up" style="animation-delay: 0.8s;">
          <div class="bg-white rounded-2xl shadow-2xl overflow-hidden border">
            <div class="bg-gray-100 px-4 py-3 flex items-center space-x-2">
              <div class="w-3 h-3 bg-red-400 rounded-full"></div>
              <div class="w-3 h-3 bg-yellow-400 rounded-full"></div>
              <div class="w-3 h-3 bg-green-400 rounded-full"></div>
              <div class="flex-1 text-center text-sm text-gray-600">OpenAsMenu</div>
            </div>
            <div class="p-8 bg-gradient-to-br from-gray-50 to-white">
              <div class="grid grid-cols-1 md:grid-cols-2 gap-8 items-center">
                <!-- 左侧：功能列表 -->
                <div class="space-y-4">
                  <h3 class="text-2xl font-bold text-gray-900 mb-6">主要功能</h3>
                  <div class="space-y-3">
                    <div class="flex items-center space-x-3">
                      <div class="w-8 h-8 bg-primary-100 rounded-full flex items-center justify-center">
                        <svg class="w-4 h-4 text-primary-600" fill="currentColor" viewBox="0 0 20 20">
                          <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"/>
                        </svg>
                      </div>
                      <span class="text-gray-700">添加/删除右键菜单项</span>
                    </div>
                    <div class="flex items-center space-x-3">
                      <div class="w-8 h-8 bg-primary-100 rounded-full flex items-center justify-center">
                        <svg class="w-4 h-4 text-primary-600" fill="currentColor" viewBox="0 0 20 20">
                          <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"/>
                        </svg>
                      </div>
                      <span class="text-gray-700">支持多种编辑器和IDE</span>
                    </div>
                    <div class="flex items-center space-x-3">
                      <div class="w-8 h-8 bg-primary-100 rounded-full flex items-center justify-center">
                        <svg class="w-4 h-4 text-primary-600" fill="currentColor" viewBox="0 0 20 20">
                          <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"/>
                        </svg>
                      </div>
                      <span class="text-gray-700">实时状态检测</span>
                    </div>
                    <div class="flex items-center space-x-3">
                      <div class="w-8 h-8 bg-primary-100 rounded-full flex items-center justify-center">
                        <svg class="w-4 h-4 text-primary-600" fill="currentColor" viewBox="0 0 20 20">
                          <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"/>
                        </svg>
                      </div>
                      <span class="text-gray-700">配置文件管理</span>
                    </div>
                  </div>
                </div>
                
                <!-- 右侧：模拟界面 -->
                <div class="bg-white rounded-lg shadow-lg border p-4">
                  <div class="border-b pb-3 mb-4">
                    <h4 class="font-semibold text-gray-900">配置管理</h4>
                  </div>
                  <div class="space-y-3">
                    <div class="flex items-center justify-between p-2 bg-gray-50 rounded">
                      <div class="flex items-center space-x-2">
                        <div class="w-4 h-4 bg-blue-500 rounded"></div>
                        <span class="text-sm">VSCode</span>
                      </div>
                      <span class="text-xs text-green-600">✓ 已启用</span>
                    </div>
                    <div class="flex items-center justify-between p-2 bg-gray-50 rounded">
                      <div class="flex items-center space-x-2">
                        <div class="w-4 h-4 bg-orange-500 rounded"></div>
                        <span class="text-sm">PyCharm</span>
                      </div>
                      <span class="text-xs text-gray-500">○ 已禁用</span>
                    </div>
                    <div class="flex items-center justify-between p-2 bg-gray-50 rounded">
                      <div class="flex items-center space-x-2">
                        <div class="w-4 h-4 bg-purple-500 rounded"></div>
                        <span class="text-sm">Cursor</span>
                      </div>
                      <span class="text-xs text-green-600">✓ 已启用</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        
        <!-- 统计数据 -->
        <div class="mt-16 grid grid-cols-1 md:grid-cols-3 gap-8 animate-slide-up" style="animation-delay: 1s;">
          <div class="text-center">
            <div class="text-3xl font-bold text-primary-600 mb-2">10+</div>
            <div class="text-gray-600">预设编辑器</div>
          </div>
          <div class="text-center">
            <div class="text-3xl font-bold text-primary-600 mb-2">100%</div>
            <div class="text-gray-600">安全可靠</div>
          </div>
          <div class="text-center">
            <div class="text-3xl font-bold text-primary-600 mb-2">免费</div>
            <div class="text-gray-600">开源软件</div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'HeroSection'
}
</script>
