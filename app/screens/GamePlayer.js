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

class GamePlayer extends Component {
	static navigationOptions = {
		headerStyle: headerStyle.sectionHeadingStyle
	};
	
	render() {
		return (
			<Container>
			
			</Container>
		);
	}
}

export default GamePlayer;