<template>
  <section id="guide" class="py-20 bg-white">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <!-- 标题 -->
      <div class="text-center mb-16">
        <h2 class="section-title">使用说明</h2>
        <p class="section-subtitle">
          简单几步，轻松配置您的右键菜单
        </p>
      </div>
      
      <!-- 使用步骤 -->
      <div class="grid grid-cols-1 lg:grid-cols-2 gap-16 mb-16">
        <!-- 左侧：步骤列表 -->
        <div class="space-y-8">
          <div v-for="(step, index) in steps" :key="step.id" 
               class="flex items-start space-x-4">
            <div class="flex-shrink-0 w-12 h-12 bg-primary-600 text-white rounded-full flex items-center justify-center font-bold text-lg">
              {{ index + 1 }}
            </div>
            <div class="flex-1">
              <h3 class="text-xl font-semibold text-gray-900 mb-2">{{ step.title }}</h3>
              <p class="text-gray-600 leading-relaxed">{{ step.description }}</p>
              <div v-if="step.tips" class="mt-3 p-3 bg-blue-50 rounded-lg">
                <div class="flex items-start space-x-2">
                  <svg class="w-5 h-5 text-blue-500 mt-0.5 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z" clip-rule="evenodd"/>
                  </svg>
                  <div class="text-sm text-blue-700">
                    <strong>提示：</strong>{{ step.tips }}
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        
        <!-- 右侧：视频演示区域 -->
        <div class="bg-gray-100 rounded-2xl p-8 flex items-center justify-center">
          <div class="text-center">
            <div class="w-24 h-24 bg-primary-600 rounded-full flex items-center justify-center mx-auto mb-6">
              <svg class="w-12 h-12 text-white" fill="currentColor" viewBox="0 0 20 20">
                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM9.555 7.168A1 1 0 008 8v4a1 1 0 001.555.832l3-2a1 1 0 000-1.664l-3-2z" clip-rule="evenodd"/>
              </svg>
            </div>
            <h3 class="text-xl font-semibold text-gray-900 mb-2">视频教程</h3>
            <p class="text-gray-600 mb-4">观看详细的使用演示</p>
            <button class="bg-primary-600 hover:bg-primary-700 text-white font-semibold py-3 px-6 rounded-lg transition-colors duration-200">
              播放教程
            </button>
          </div>
        </div>
      </div>
      
      <!-- 常见问题 -->
      <div class="mb-16">
        <h3 class="text-2xl font-bold text-gray-900 text-center mb-8">常见问题</h3>
        <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
          <div v-for="faq in faqs" :key="faq.id" class="bg-gray-50 rounded-lg p-6">
            <h4 class="font-semibold text-gray-900 mb-3 flex items-center">
              <svg class="w-5 h-5 text-primary-600 mr-2" fill="currentColor" viewBox="0 0 20 20">
                <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-8-3a1 1 0 00-.867.5 1 1 0 11-1.731-1A3 3 0 0113 8a3.001 3.001 0 01-2 2.83V11a1 1 0 11-2 0v-1a1 1 0 011-1 1 1 0 100-2zm0 8a1 1 0 100-2 1 1 0 000 2z" clip-rule="evenodd"/>
              </svg>
              {{ faq.question }}
            </h4>
            <p class="text-gray-600 leading-relaxed">{{ faq.answer }}</p>
          </div>
        </div>
      </div>
      
      <!-- 技术支持 -->
      <div class="bg-gradient-to-r from-primary-50 to-blue-50 rounded-2xl p-8">
        <div class="text-center mb-8">
          <h3 class="text-2xl font-bold text-gray-900 mb-4">需要帮助？</h3>
          <p class="text-gray-600">我们提供多种方式来为您提供支持</p>
        </div>
        
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div class="text-center p-6 bg-white rounded-lg shadow-sm">
            <div class="w-12 h-12 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg class="w-6 h-6 text-green-600" fill="currentColor" viewBox="0 0 20 20">
                <path d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"/>
              </svg>
            </div>
            <h4 class="font-semibold text-gray-900 mb-2">在线文档</h4>
            <p class="text-gray-600 text-sm mb-4">查看详细的使用文档和API参考</p>
            <a href="#" class="text-primary-600 hover:text-primary-700 text-sm font-medium">查看文档 →</a>
          </div>
          
          <div class="text-center p-6 bg-white rounded-lg shadow-sm">
            <div class="w-12 h-12 bg-blue-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg class="w-6 h-6 text-blue-600" fill="currentColor" viewBox="0 0 24 24">
                <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z"/>
              </svg>
            </div>
            <h4 class="font-semibold text-gray-900 mb-2">GitHub Issues</h4>
            <p class="text-gray-600 text-sm mb-4">报告问题或提出功能建议</p>
            <a href="#" class="text-primary-600 hover:text-primary-700 text-sm font-medium">提交问题 →</a>
          </div>
          
          <div class="text-center p-6 bg-white rounded-lg shadow-sm">
            <div class="w-12 h-12 bg-purple-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg class="w-6 h-6 text-purple-600" fill="currentColor" viewBox="0 0 20 20">
                <path d="M2 3a1 1 0 011-1h2.153a1 1 0 01.986.836l.74 4.435a1 1 0 01-.54 1.06l-1.548.773a11.037 11.037 0 006.105 6.105l.774-1.548a1 1 0 011.059-.54l4.435.74a1 1 0 01.836.986V17a1 1 0 01-1 1h-2C7.82 18 2 12.18 2 5V3z"/>
              </svg>
            </div>
            <h4 class="font-semibold text-gray-900 mb-2">社区支持</h4>
            <p class="text-gray-600 text-sm mb-4">加入用户社区，获得帮助</p>
            <a href="#" class="text-primary-600 hover:text-primary-700 text-sm font-medium">加入社区 →</a>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'GuideSection',
  setup() {
    const steps = [
      {
        id: 1,
        title: '下载并运行程序',
        description: '从官网下载最新版本的 OpenAsMenu，以管理员身份运行程序。程序会自动检测权限并提示提升。',
        tips: '首次运行时，Windows可能会显示安全警告，这是正常现象，请选择"仍要运行"。'
      },
      {
        id: 2,
        title: '选择或添加配置',
        description: '在左侧配置列表中选择预设的编辑器配置，或点击"添加新配置"按钮创建自定义配置。',
        tips: '程序内置了常用编辑器的配置，如VSCode、PyCharm等，可以直接使用。'
      },
      {
        id: 3,
        title: '配置详细信息',
        description: '在右侧配置区域设置显示名称、程序路径、应用范围等参数。可以使用浏览按钮选择程序路径。',
        tips: '确保程序路径正确，程序会自动验证路径的有效性。'
      },
      {
        id: 4,
        title: '启用右键菜单',
        description: '勾选"启用右键菜单"复选框，然后点击"应用更改"按钮。程序会将配置写入Windows注册表。',
        tips: '应用更改后，立即在文件资源管理器中右键测试，查看菜单是否正常显示。'
      },
      {
        id: 5,
        title: '测试和使用',
        description: '打开文件资源管理器，在文件或文件夹上右键，查看新添加的菜单项。点击菜单项即可用对应程序打开。',
        tips: '如果菜单项没有显示，请检查程序路径是否正确，或重启文件资源管理器。'
      }
    ]
    
    const faqs = [
      {
        id: 1,
        question: '为什么需要管理员权限？',
        answer: '因为程序需要修改Windows注册表来添加右键菜单项，这个操作需要管理员权限才能完成。'
      },
      {
        id: 2,
        question: '右键菜单没有显示怎么办？',
        answer: '请检查程序路径是否正确，确保目标程序存在。如果路径正确，尝试重启文件资源管理器或重新启动计算机。'
      },
      {
        id: 3,
        question: '如何删除已添加的菜单项？',
        answer: '在程序中取消勾选对应配置的"启用右键菜单"复选框，然后点击"应用更改"即可删除。'
      },
      {
        id: 4,
        question: '支持哪些操作系统？',
        answer: '支持Windows 7及以上版本的操作系统，包括Windows 10和Windows 11。'
      },
      {
        id: 5,
        question: '配置文件保存在哪里？',
        answer: '配置文件保存在程序目录下的menu_configs.json文件中，您可以备份此文件来保存配置。'
      },
      {
        id: 6,
        question: '程序是否安全？',
        answer: '程序完全开源，代码透明，不包含任何恶意功能。所有操作都是标准的Windows API调用。'
      }
    ]
    
    return {
      steps,
      faqs
    }
  }
}
</script>
