<template>
  <footer class="bg-gray-900 text-gray-300">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
      <div class="grid grid-cols-1 md:grid-cols-4 gap-8">
        <!-- 产品信息 -->
        <div class="col-span-1 md:col-span-2">
          <div class="flex items-center mb-4">
            <div class="w-8 h-8 bg-primary-600 rounded-lg flex items-center justify-center mr-3">
              <svg class="w-5 h-5 text-white" fill="currentColor" viewBox="0 0 20 20">
                <path d="M3 4a1 1 0 011-1h12a1 1 0 011 1v2a1 1 0 01-1 1H4a1 1 0 01-1-1V4zM3 10a1 1 0 011-1h6a1 1 0 011 1v6a1 1 0 01-1 1H4a1 1 0 01-1-1v-6zM14 9a1 1 0 00-1 1v6a1 1 0 001 1h2a1 1 0 001-1v-6a1 1 0 00-1-1h-2z"/>
              </svg>
            </div>
            <span class="text-xl font-bold text-white">OpenAsMenu</span>
          </div>
          <p class="text-gray-400 mb-6 max-w-md">
            专业的Windows右键菜单管理工具，让您的工作更加高效便捷。免费开源，安全可靠。
          </p>
          <div class="flex space-x-4">
            <a href="https://github.com/yourusername/OpenAsMenu" 
               target="_blank"
               class="text-gray-400 hover:text-white transition-colors">
              <svg class="w-6 h-6" fill="currentColor" viewBox="0 0 24 24">
                <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z"/>
              </svg>
            </a>
            <a href="#" class="text-gray-400 hover:text-white transition-colors">
              <svg class="w-6 h-6" fill="currentColor" viewBox="0 0 24 24">
                <path d="M23.953 4.57a10 10 0 01-2.825.775 4.958 4.958 0 002.163-2.723c-.951.555-2.005.959-3.127 1.184a4.92 4.92 0 00-8.384 4.482C7.69 8.095 4.067 6.13 1.64 3.162a4.822 4.822 0 00-.666 2.475c0 1.71.87 3.213 2.188 4.096a4.904 4.904 0 01-2.228-.616v.06a4.923 4.923 0 003.946 4.827 4.996 4.996 0 01-2.212.085 4.936 4.936 0 004.604 3.417 9.867 9.867 0 01-6.102 2.105c-.39 0-.779-.023-1.17-.067a13.995 13.995 0 007.557 2.209c9.053 0 13.998-7.496 13.998-13.985 0-.21 0-.42-.015-.63A9.935 9.935 0 0024 4.59z"/>
              </svg>
            </a>
          </div>
        </div>
        
        <!-- 快速链接 -->
        <div>
          <h3 class="text-white font-semibold mb-4">快速链接</h3>
          <ul class="space-y-2">
            <li><a href="#home" class="hover:text-white transition-colors">首页</a></li>
            <li><a href="#features" class="hover:text-white transition-colors">功能特性</a></li>
            <li><a href="#screenshots" class="hover:text-white transition-colors">产品截图</a></li>
            <li><a href="#download" class="hover:text-white transition-colors">下载</a></li>
            <li><a href="#guide" class="hover:text-white transition-colors">使用说明</a></li>
          </ul>
        </div>
        
        <!-- 支持 -->
        <div>
          <h3 class="text-white font-semibold mb-4">支持</h3>
          <ul class="space-y-2">
            <li><a href="#" class="hover:text-white transition-colors">使用文档</a></li>
            <li><a href="#" class="hover:text-white transition-colors">常见问题</a></li>
            <li><a href="#" class="hover:text-white transition-colors">问题反馈</a></li>
            <li><a href="#" class="hover:text-white transition-colors">更新日志</a></li>
            <li><a href="#" class="hover:text-white transition-colors">联系我们</a></li>
          </ul>
        </div>
      </div>
      
      <!-- 分割线 -->
      <div class="border-t border-gray-800 mt-8 pt-8">
        <div class="flex flex-col md:flex-row justify-between items-center">
          <div class="text-gray-400 text-sm">
            © 2024 OpenAsMenu. 保留所有权利。
          </div>
          <div class="flex items-center space-x-6 mt-4 md:mt-0">
            <a href="#" class="text-gray-400 hover:text-white text-sm transition-colors">隐私政策</a>
            <a href="#" class="text-gray-400 hover:text-white text-sm transition-colors">使用条款</a>
            <a href="#" class="text-gray-400 hover:text-white text-sm transition-colors">开源许可</a>
          </div>
        </div>
      </div>
    </div>
  </footer>
</template>

<script>
export default {
  name: 'Footer'
}
</script>
