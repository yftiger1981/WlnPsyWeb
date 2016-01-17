/**
 * @fileOverview RUM Auth SDK
 * @author wanglin576@pingan.com.cn
 */
var RumAuth = RumAuth || {};

RumAuth = {
	
	/**
	 * 版本
	 * @type String
	 * @static
	 */
	version : '1.0.0',
	
	/**
	 * 内部全部变量
	 * @private
	 */
	_config : {
		
		/**
		 * RUM应用ID
		 * @type String
		 * @default 10023
		 * @private
		 */
		appid: '10023',
		
		/**
		 * 密钥
		 * @type String
		 * @private
		 */
		secret: '',
		
		/**
		 * 签名
		 */
		sign: '',
		/**
		 * 授权凭证
		 * @type String
		 * @private
		 */
		token: '',
		
		/**
		 * 域名
		 * @type String
		 * @public API
		 */	
		domain: document.domain,
		
		/**
		 * 一账通主机
		 * @type String
		 * @public API
		 */
		oneHost: 'https://member.pingan.com.cn',
		
		/**
		 * RUM主机
		 * @type String
		 * @public API
		 */
		rumHost: 'http://www.pingan.com',
		
		/**
		 * 调试
		 * @type String
		 * @public API
		 */	
		debug: ''
	},
	
	/**
	 * 私有方法对象定义
	 * @private
	 */
	_fn : {},
	
	/**
	 * 私有工具对象定义
	 * @private
	 */
	_util : {}
};

/**
 * 功能函数
 * 
 */
(function(fn, util, config) {
	
	fn.rum = {
		
		/**
		 * 登录认证功能
		 * @method RumAuth.rum.login
		 * @param {callback} 必选，登录后执行的回调函数。
		 * @return Number,0登陆成功,102登陆失败
		 */ 
		login: function(clientNo, callback) {
			 
			fn.one.getLoginInfo(clientNo, function(response) {
				 var data = '3desAssertSign=' + encodeURIComponent(response.data['3desAssertSign'])+'&3desAssert=' + encodeURIComponent(response.data['3desAssert']);
				 var url = config.rumHost + '/customer/flowLogin.ajax?' + data;
				 
				 util.getJSON(url, function(json) {
					callback(json.resultCode);
				});
			 });
			
		},
		
		
		/**
		 * 检查RUM是否登录
		 * @method RumAuth.rum.isLogin
		 * @param callback 必选参数,回调函数
		 * @return Number 0已登录, 102未登录。
		 */
		isLogin : function(callback) {
			var url = config.rumHost + '/customer/query-user-info.ajax';
			util.getJSON(url, function(json) {
				callback(json.resultCode);				
			});
		},
		
		/**
		 * 退出登录功能
		 * @method RumAuth.rum.logout
		 */
		logout: function() {
			window.location.href = config.oneHost + '/pinganone/pa/fcmmLogOut.do';
		},
		
		/**
		 * 获得RUM用户信息,用户基本信息,车辆信息，房屋信息，联系人，联系地址
		 * 调用时使用setTimeOut，如果在指定时间内此方法无返回，则认为调用失败
		 * @method RumAuth.rum.getUserInfo
		 * @param callback 必选，获得RUM用户信息后的回调函数
		 * @param params 输入参数isQueryUser基本信息,isQueryContactMans联系人信息,isQueryHouses房屋信息,isQueryVehicle车辆信息,isQueryContactAddresses联系地址
		 * @return 用户信息
		 */
		getUserInfo: function(params, callback) {
			var url = config.rumHost + '/customer/query-user-info.ajax?' + params;
			util.getJSON(url, function(json) {
				
				// rum已登陆,直接返回用户信息
				if (json.resultCode == '0') {
					
					callback(json);
					
				} else if (json.resultCode == '102') {
					
					// RUM未登陆,先判断一账通会员是否登陆
					fn.one.isLogin(function(clientNo) {
						
						// 一账通登陆,则登陆RUM
						if(clientNo) {
							
							fn.rum.login(clientNo, function(resultCode) {
								if(resultCode == '0'){
									util.getJSON(url, function(json1) {
										callback(json1);
									});
								} else {
									callback(json);
								}
							});
							
						} else {
							callback(json);
						}
					});
					
				} else {
					
					// 系统错误
					callback(json);
				}
				
			});
		},
		
		/**
		 * 获取时间戳
		 * @method 内部函数
		 * @param callback 必选，获得后的回调函数
		 * @return json 时间戳
		 */
		getTimeSign: function(type, loginName, callback) {
			var url = config.rumHost + '/customer/time-sign.ajax?type=' + type + '&loginName=' + loginName;
			util.getJSON(url, function(json) {
				callback(json);
			});
		},
		
		/**
		 * 获取Sign
		 * @method 内部函数
		 * @param token 必选，token
		 * @param callback 必选，获得后的回调函数
		 * @return JSON Sign
		 */
		getTokenSign: function(clientNo, callback){
			var url = config.rumHost + '/customer/token-sign.ajax?clientNo=' + clientNo;
			util.getJSON(url, function(json) {
				// if (data.status == 'success') {
				// self.sign = data.sign;
				callback(json);
			});
		}
		 
	};
	
	
	fn.one = {
		
		/**
		 * 判断一账通是否已登陆
		 * 获取状态：fail失败，success成功
		 * 登陆状态：0代表未登陆，1代表已登陆
		 * 消息状态：如果已登陆，则消息值用户会员ID
		 * @method Rum.one.login
		 * @param {callback} 回调函数
		 * @return Boolean
		 */
		isLogin: function(callback) {
			
			util.log('判断一账通是否已登陆');
			var self =  this, url = config.oneHost + '/pinganone/pa/fcmmIsLogin.do?appId='+ config.appid +'&callBack=?';
			
			util.ajax({
				type: 'get',
				url: url,
				dataType:'json',
				cache: false,
				success: function(json) {
					util.log(json.data.message);
					if (json.status == 'success' && (json.data.errorCode == '1' || json.data.message == '该接口不允许第三方用户使用') ) {
						callback(json.data.message);
						
					} else {
						util.log('一账通返回:' + json.status + ',errorCode:' + json.data.errorCode + ',message:' + json.data.message);
						callback('');
					}
				},
				error:function() {
					callback('');
					util.log('请求失败');
				}
			});
		},
		
		/**
		 * 功能：会员统一退出
		 * 说明：该接口会退出所有接入的会员网站并退出一账通
		 */
		logOut : function() {
			window.location.href = config.oneHost + '/pinganone/pa/fcmmLogOut.do';
		},
		
		/**
		 * 验证机或者邮箱
		 * @param type 是验证手机还是验证邮箱
		 * @param name 手机或者邮箱的值
		 * @return Boolean
		 */
		 checkLoginName: function(type,name,callback) {
			
			// 获取signature以及timestamp
			fn.rum.getTimeSign(type, name, function(json) {
				var data = 'appId='+ config.appid + '&timestamp=' + json.timestamp + '&type=' + type + '&loginName=' + name + '&signature=' + json.sign + '&callBack=?';
				var url = config.oneHost+'/pinganone/pa/getClientNoByLoginName.do?' + data; 
				
				// 去一账通取clientNo
				util.ajax({
					type: 'get',
					url: url,
					dataType:'json',
					cache: false,
					success: function(response){
						util.log('clientNo:' + response.data.clientNo + ',message:' + response.data.message);
						callback(response);
					},
					error: function() {
						util.log('ajax error');
					}
				});
			});
		},
		
		getLoginToken: function(data,callback) {
			
			var self = this,
			url = config.oneHost + '/pinganone/pa/fcmmGetLoginToken.do?appId='+ config.appid + '&timestamp='+ data.timestamp +'&signature='+ data.sign +'&callBack=?';
		
			util.ajax({
				type: 'GET',
				url: url,
				dataType: 'json',
				cache: false,
				contentType: 'application/x-www-form-urlencoded;charset=GBK',
				success: function(json) {
					if (json.status == 'success' && json.data.errorCode == '1') {
						//Rum.Utile.showLog(json.data.message);
						//self.token = json.data.message;
						callback(json);
					} else {
						//Rum.Utile.showLog('status:' + json.status + ',errorCode:' + json.data.errorCode + ',message:' + json.data.message);
						callback(json);
					}
				}
			});
		},
		
		/**
		 * 获取用户会员信息接口
		 * 如果用户已登录，则返回包含个会员系统定制的用户信息
		 */
		getLoginInfo: function(clientNo, callback) {
			var argsLen = arguments.length;
			
			// getLoginInfo(function(){})
			if (argsLen === 1) {
		      callback = clientNo;
		      clientNo = '';
		    }
		    
			// 获取时间戳信息和签名
			fn.rum.getTokenSign(clientNo, function(json) {
				var cNo = json.clientNo || clientNo || '';
				
				if(cNo) {
					// 获取登陆的一账通会员信息
					var url = config.oneHost + '/pinganone/pa/fcmmGetLoginInfoV2.do?appId='+ json.appId + '&timestamp=' + json.timestamp +'&signature='+ encodeURIComponent(json.sign) +'&clientNo='+ cNo +'&isOther='+ json.isOther +'&callBack=?';
					util.ajax({
						type: 'GET',
						url: url,
						cache: false,
						dataType: 'json',
						success: function(response) {
							callback(response);
						}
					});
				} else {
					callback({"msg":"登陆已超时，请重新登陆!","status":"fail"});
				}
			});
		}
	};

})(RumAuth._fn, RumAuth._util, RumAuth._config);


/**
 * 配置项管理
 */
(function(fn, config) {
	
	var domain = document.domain;
	
	// 如果是测试环境则修改oneHost为测试环境
	if (/stg|p1/.test(domain)) {
		config.oneHost = 'https://test-member.pingan.com.cn';
		config.rumHost = 'http://' + domain;
	}
	
	if (/localhost/.test(domain)) {
		config.oneHost = 'https://hsz-7897.paic.com.cn:7002';
		config.rumHost = 'http://localhost:7002';
	}
	// 处理用户定义的配置项
	fn.config = function(options) {
		for (var k in options) {
			var previous = config[k];
			var current = options[k];

			if (typeof previous !== 'undefined') {
				config[k] = current;
			}
		 }
		 return this;
	};
	
})(RumAuth._fn, RumAuth._config);


/**
 * 工具类
 */
(function(util, config, $) {
	
	util.ajax = $.ajax;
	
	util.getJSON =  function(url, callback) {
		$.ajax({
			type: 'get',
			url: url,
			dataType: 'json',
			cache: false,
			success: function(json){
				util.log(json);
				callback(json);
			},
			error: function(){
				util.log('ajax error');
			}
		});
	};  
	
	util.log = function(obj) {
		if (config.debug && typeof console !== 'undefined') {
			console.log( obj );
		}
	};
	
	function join(args) {
		return Array.prototype.join.call(args, ' ');
	}
	
})(RumAuth._util,RumAuth._config, jQuery);
	
/**
 * @fileoverview 定义RumAuth提供的公共API
 */
(function(auth, config, fn, global){
	
	// 避免多次加载时产生冲突
	/*
	if ( auth._anth ) {
		global.auth = auth._auth;
		return;
	}*/
	
	/**
	 * 一账通公共API
	 * @public API
	 */
	auth.one = {
		
		isLogin : fn.one.isLogin,
		checkLoginName: fn.one.checkLoginName,
		getLoginInfo: fn.one.getLoginInfo
		
	};
	
	/**
	 * RUM公共API
	 * @public API
	 */
	auth.rum = {
		login : fn.rum.login,
		isLogin : fn.rum.isLogin,
		getUserInfo : fn.rum.getUserInfo
	};
	
	/**
	 * 配置项定义
	 * @public API
	 */
	auth.config = fn.config;
	
	delete auth._fn;
	
})(RumAuth, RumAuth._config, RumAuth._fn, window);
