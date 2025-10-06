<template>
  <section id="download" class="py-20 bg-primary-600">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="text-center mb-16">
        <h2 class="text-3xl md:text-4xl font-bold text-white mb-4">立即下载使用</h2>
        <p class="text-xl text-primary-100 mb-8 max-w-3xl mx-auto">
          免费开源，支持 Windows 7 及以上系统，立即体验强大的右键菜单管理功能
        </p>
      </div>
      
      <!-- 下载选项 -->
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8 mb-16">
        <!-- 最新版本 -->
        <div class="bg-white rounded-2xl shadow-xl p-8 text-center hover:scale-105 transform transition-all duration-300">
          <div class="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
            <svg class="w-8 h-8 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 10v6m0 0l-3-3m3 3l3-3m2 8H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"/>
            </svg>
          </div>
          <h3 class="text-xl font-bold text-gray-900 mb-2">最新稳定版</h3>
          <p class="text-gray-600 mb-4">推荐下载，包含所有最新功能</p>
          <div class="text-2xl font-bold text-primary-600 mb-4">v1.0.0</div>
          <button class="w-full bg-primary-600 hover:bg-primary-700 text-white font-semibold py-3 px-6 rounded-lg transition-colors duration-200 mb-3">
            下载 (.exe)
          </button>
          <div class="text-sm text-gray-500">
            大小: 15.2 MB<br>
            更新: 2024-01-15
          </div>
        </div>
        
        <!-- 便携版 -->
        <div class="bg-white rounded-2xl shadow-xl p-8 text-center hover:scale-105 transform transition-all duration-300">
          <div class="w-16 h-16 bg-blue-100 rounded-full flex items-center justify-center mx-auto mb-4">
            <svg class="w-8 h-8 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4m0-10L4 7m8 4v10M4 7v10l8 4"/>
            </svg>
          </div>
          <h3 class="text-xl font-bold text-gray-900 mb-2">便携版</h3>
          <p class="text-gray-600 mb-4">无需安装，解压即用</p>
          <div class="text-2xl font-bold text-blue-600 mb-4">v1.0.0</div>
          <button class="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-3 px-6 rounded-lg transition-colors duration-200 mb-3">
            下载 (.zip)
          </button>
          <div class="text-sm text-gray-500">
            大小: 12.8 MB<br>
            更新: 2024-01-15
          </div>
        </div>
        
        <!-- 源代码 -->
        <div class="bg-white rounded-2xl shadow-xl p-8 text-center hover:scale-105 transform transition-all duration-300">
          <div class="w-16 h-16 bg-gray-100 rounded-full flex items-center justify-center mx-auto mb-4">
            <svg class="w-8 h-8 text-gray-600" fill="currentColor" viewBox="0 0 24 24">
              <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z"/>
            </svg>
          </div>
          <h3 class="text-xl font-bold text-gray-900 mb-2">源代码</h3>
          <p class="text-gray-600 mb-4">查看源码，参与开发</p>
          <div class="text-2xl font-bold text-gray-600 mb-4">GitHub</div>
          <button class="w-full bg-gray-800 hover:bg-gray-900 text-white font-semibold py-3 px-6 rounded-lg transition-colors duration-200 mb-3">
            查看源码
          </button>
          <div class="text-sm text-gray-500">
            MIT 许可证<br>
            开源免费
          </div>
        </div>
      </div>
      
      <!-- 系统要求 -->
      <div class="bg-primary-700 rounded-2xl p-8 mb-16">
        <h3 class="text-2xl font-bold text-white text-center mb-8">系统要求</h3>
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
          <div class="text-center">
            <div class="w-12 h-12 bg-primary-500 rounded-lg flex items-center justify-center mx-auto mb-3">
              <svg class="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 20 20">
                <path d="M3 4a1 1 0 011-1h12a1 1 0 011 1v2a1 1 0 01-1 1H4a1 1 0 01-1-1V4zM3 10a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H4a1 1 0 01-1-1v-6zM14 9a1 1 0 00-1 1v6a1 1 0 001 1h2a1 1 0 001-1v-6a1 1 0 00-1-1h-2z"/>
              </svg>
            </div>
            <div class="text-primary-100 font-medium">操作系统</div>
            <div class="text-white text-sm">Windows 7+</div>
          </div>
          <div class="text-center">
            <div class="w-12 h-12 bg-primary-500 rounded-lg flex items-center justify-center mx-auto mb-3">
              <svg class="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 20 20">
                <path d="M13 6a3 3 0 11-6 0 3 3 0 016 0zM18 8a2 2 0 11-4 0 2 2 0 014 0zM14 15a4 4 0 00-8 0v3h8v-3z"/>
              </svg>
            </div>
            <div class="text-primary-100 font-medium">权限</div>
            <div class="text-white text-sm">管理员权限</div>
          </div>
          <div class="text-center">
            <div class="w-12 h-12 bg-primary-500 rounded-lg flex items-center justify-center mx-auto mb-3">
              <svg class="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 20 20">
                <path d="M3 3a1 1 0 000 2v8a2 2 0 002 2h2.586l-1.293 1.293a1 1 0 101.414 1.414L10 15.414l2.293 2.293a1 1 0 001.414-1.414L12.414 15H15a2 2 0 002-2V5a1 1 0 100-2H3z"/>
              </svg>
            </div>
            <div class="text-primary-100 font-medium">运行时</div>
            <div class="text-white text-sm">.NET 8.0</div>
          </div>
          <div class="text-center">
            <div class="w-12 h-12 bg-primary-500 rounded-lg flex items-center justify-center mx-auto mb-3">
              <svg class="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 20 20">
                <path d="M3 4a1 1 0 011-1h12a1 1 0 011 1v2a1 1 0 01-1 1H4a1 1 0 01-1-1V4zM3 10a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H4a1 1 0 01-1-1v-6zM14 9a1 1 0 00-1 1v6a1 1 0 001 1h2a1 1 0 001-1v-6a1 1 0 00-1-1h-2z"/>
              </svg>
            </div>
            <div class="text-primary-100 font-medium">存储空间</div>
            <div class="text-white text-sm">20 MB</div>
          </div>
        </div>
      </div>
      
      <!-- 下载统计 -->
      <div class="text-center">
        <div class="grid grid-cols-1 md:grid-cols-3 gap-8">
          <div>
            <div class="text-3xl font-bold text-white mb-2">1,000+</div>
            <div class="text-primary-100">总下载量</div>
          </div>
          <div>
            <div class="text-3xl font-bold text-white mb-2">4.9/5</div>
            <div class="text-primary-100">用户评分</div>
          </div>
          <div>
            <div class="text-3xl font-bold text-white mb-2">100%</div>
            <div class="text-primary-100">安全无毒</div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'DownloadSection'
}
</script>
