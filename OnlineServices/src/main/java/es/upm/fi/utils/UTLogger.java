package es.upm.fi.utils;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;


import org.apache.logging.log4j.LogManager;


public class UTLogger {
	private static UTLogger.IceLoggerAdapter iceLoggerAdapter = new UTLogger.IceLoggerAdapter("", "");

	public static void trace(String module, String message) {
		org.apache.logging.log4j.Logger logger = LogManager.getLogger(module);
		logger.trace(message);
	}

	public static void debug(String module, String message) {
		org.apache.logging.log4j.Logger logger = org.apache.logging.log4j.LogManager.getLogger(module);
		logger.debug(message);
	}

	public static void debug(String message) {
		UTLogger.debug("", message);
	}

	public static void info(String module, String message) {
		org.apache.logging.log4j.Logger logger = org.apache.logging.log4j.LogManager.getLogger(module);
		logger.info(message);
	}

	public static void info(String message) {
		UTLogger.info("", message);
	}

	public static void warn(String module, String message) {
		org.apache.logging.log4j.Logger logger = org.apache.logging.log4j.LogManager.getLogger(module);
		logger.warn(message);
	}

	public static void warn(String message) {
		UTLogger.warn("", message);
	}

	public static void error(String module, String message) {
		org.apache.logging.log4j.Logger logger = org.apache.logging.log4j.LogManager.getLogger(module);
		logger.error(message);
	}

	public static void error(String message) {
		UTLogger.error("", message);
	}

	public static void fatal(String module, String message) {
		org.apache.logging.log4j.Logger logger = org.apache.logging.log4j.LogManager.getLogger(module);
		logger.fatal(message);
	}

	public static void error(String module, Throwable t) {
		org.apache.logging.log4j.Logger logger = org.apache.logging.log4j.LogManager.getLogger(module);
		logger.error(t);
	}

	static class IceLoggerAdapter extends Ice.LoggerI {
		private static final String module = "ICE.LOGGER";

		public IceLoggerAdapter(String prefix, String file) {
			super(prefix, file);
		}

		@Override
		protected void finalize() {
			try {
				super.finalize();
			} catch (Throwable e) {
				e.printStackTrace();
			}
		}

		@Override
		public void print(String message) {
			UTLogger.debug(module, message);
		}

		@Override
		public void trace(String category, String message) {
			UTLogger.info(category, message);
		}

		@Override
		public void warning(String message) {
			UTLogger.warn(module, message);
		}

		@Override
		public void error(String message) {
			UTLogger.error(module, message);
		}

		@Override
		public Ice.Logger cloneWithPrefix(String prefix) {
			return super.cloneWithPrefix(prefix);
		}
	}

	public static void initLogger(int statLogInterval_, Map<String, String> _cfg) {
	}

	static class StatInfo {
		public String action;
		public long count;
		public long maxCost;
		public long minCost;
		public long avgCost;
	}

	static class StatInfoMonitor implements Runnable {
		public void run() {
			HashMap<Long, StatInfo> statMap = new HashMap<Long, StatInfo>();
			Collection<StatInfo> infos = statMap.values();
			org.apache.logging.log4j.Logger infoLogger = org.apache.logging.log4j.LogManager.getLogger(STAT_INFO_LOG);

			if (infos.size() > 0) {
				infoLogger.info("");
				infoLogger.info("");
				infoLogger.info("");
				infoLogger.info(String.format("---------------------- StatInfo Begin ---------------------- "));
				for (StatInfo tmpInfo : infos) {
					infoLogger.info(
							String.format("action:[%s] count:[%d] minCost:[%d ms] maxCost:[%d ms] avgCost:[%d ms]",
									tmpInfo.action, tmpInfo.count, tmpInfo.minCost, tmpInfo.maxCost, tmpInfo.avgCost));
				}
				infoLogger.info(String.format("---------------------- StatInfo End ---------------------- "));
				infoLogger.info("");
				infoLogger.info("");
				infoLogger.info("");
			}
		}
	}

	private static int statInfoInterval = 60;

	public static final String SESSION_LOG = "SESSION";
	public static final String AUTH_LOG = "AUTH";
	public static final String CHAT_LOG = "CHAT";
	public static final String ACCOUNT_LOG = "ACCOUNT";

	public static final String STAT_INFO_LOG = "STAT_INFO";
}
