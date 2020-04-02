import React, {Component} from 'react';
import {
    View,
    Text,
    Image,
    ImageBackground
} from 'react-native';
import {WebView} from 'react-native-webview';
import {
    Icon,
    Button,
    Container,
    Header,
    Content,
    Left,
    Body,
    Card,
    CardItem,
    Right
} from 'native-base';

import headerStyle from '../styles/SideMenu.style';
import infoPageStyle from '../styles/InfoPage.style';
import GameStyle from '../styles/Game.style';
import {Fonts} from '../components/Fonts';

import HandleBack from '../components/PauseOnBack'

import UnityView, { UnityModule } from 'react-native-unity-view'

import { StackActions } from 'react-navigation';

class GamePlayer extends Component {
	static navigationOptions = {
		headerMode: 'none',
		header: null,
	};
	
	onBack = () => {
		UnityModule.pause();
		this.props.navigation.dispatch(StackActions.pop({n: 1,}));
		return true;
	};
	
	render() {
		return (
			<HandleBack onBack={this.onBack}>
				<View style={{ position: 'absolute', left: 0, right: 0, top: 0, bottom: 0, }} >
					<UnityView style={{ position: 'absolute', left: 0, right: 0, top: 0, bottom: 0, }} />
				</View>
			</HandleBack>
		);
	}
}

export default GamePlayer;